using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _0_FrameWork.Domain.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public T GetById(TKey id)
        {
            return _context.Find<T>(id);
        }

        public void Create(T entity)
        {
           
                var property = entity.GetType().GetProperty("LanguageId");
                var culture = CultureInfo.CurrentCulture.Name;
                if (property != null && property.CanWrite)
                {
                    switch (culture)
                    {
                        case "prs":
                            property.SetValue(entity,(long?)1);
                            break;
                        case "en":
                            property.SetValue(entity,(long?)2);
                            break;
                    }
                }
                _context.Add(entity);
           
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public IQueryable<T> Search()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}


