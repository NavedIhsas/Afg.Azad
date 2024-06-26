using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.Language;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Domain.Quiz;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class QuizRepository : RepositoryBase<long, Quiz>, IQuizRepository
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;
        private readonly ILanguageApplication _languageApplication;
        public QuizRepository(ShopContext context, IMapper mapper, ILanguageApplication languageApplication) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _languageApplication = languageApplication;
        }

        public EditQuiz GetDetails(long id)
        {
            var quiz = _context.Quizzes.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<EditQuiz>(quiz);
        }

        public List<QuizViewModel> GetAll()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _mapper.Map<List<QuizViewModel>>(_context.Quizzes.Where(x => x.LanguageId == langId).Include(x => x.Course).ToList());
        }

        public List<QuizViewModel> SelectList()
        {
            var langId = _languageApplication.GetLanguageCulture(CultureInfo.CurrentCulture.Name);
            return _context.Quizzes.Where(x => x.LanguageId == langId).Select(x => new { x.Id, x.Name }).AsNoTracking()
                 .Select(x => new QuizViewModel() { Id = x.Id, Name = x.Name }).ToList();
        }

    }
}
