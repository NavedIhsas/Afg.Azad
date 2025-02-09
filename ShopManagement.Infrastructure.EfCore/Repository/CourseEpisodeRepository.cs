﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.CourseEpisode;
using Shop.Management.Application.Contract.Language;
using ShopManagement.Domain.CourseEpisodeAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CourseEpisodeRepository : RepositoryBase<long, CourseEpisode>, ICourseEpisodeRepository
    {
        private readonly ShopContext _context;
        private readonly ILanguageApplication _languageApplication;
        public CourseEpisodeRepository(ShopContext dbContext, ShopContext context, ILanguageApplication languageApplication) : base(dbContext)
        {
            _context = context;
            _languageApplication = languageApplication;
        }

        public EditCourseEpisodeViewModel GetDetails(long id)
        {
            return _context.CourseEpisodes.Select(x => new EditCourseEpisodeViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsFree = x.IsFree,
                Time = x.Time,
                CourseId = x.CourseId,
                FileName = x.FileName
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CourseEpisodeViewModel> Search(CourseEpisodeSearchModel command)
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);

            var query = _context.CourseEpisodes.Where(x=>x.LanguageId==langId).Include(x => x.Course).Select(x => new CourseEpisodeViewModel
            {
                Title = x.Title,
                IsFree = x.IsFree,
                Time = x.Time,
                CourseName = x.Course.Name,
                FileName = x.FileName,
                CourseId = x.CourseId,
                Id = x.Id
            }).ToList();

            if (!string.IsNullOrWhiteSpace(command.Title))
                query = query.Where(x => x.Title.Contains(command.Title.Trim())).ToList();

            if (command.CourseId > 0)
                query = query.Where(x => x.CourseId == command.CourseId).ToList();

            var orderly = query.OrderByDescending(x => x.Id).ToList();

            return orderly;
        }

        public string GetCourseGroupSlugBy(long courseId)
        {
            var course = _context.CourseEpisodes.Include(x => x.Course).ThenInclude(x => x.CourseGroup)
                .FirstOrDefault(x => x.Course.Id == courseId)?.Course.CourseGroup.Slug;
            return course;
        }

        public CourseEpisodeViewModel GetEpisodeIdBy(long courseId)
        {
            return _context.CourseEpisodes.Include(x => x.Course).Select(x => new CourseEpisodeViewModel
                {
                    Id = x.Id,
                    CourseId = x.CourseId
                })
                .FirstOrDefault(x => x.CourseId == courseId);
        }
    }
}