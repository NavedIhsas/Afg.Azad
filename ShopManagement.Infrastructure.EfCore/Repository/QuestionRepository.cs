using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Application.Contract.Quiz;
using ShopManagement.Domain.Quiz;

namespace ShopManagement.Infrastructure.EfCore.Repository;

public class QuestionRepository:RepositoryBase<long, Question>, IQuestionRepository
{
    private readonly ShopContext _context;
    private readonly IMapper _mapper;
    public QuestionRepository(ShopContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public EditQuestion GetDetails(long id)
    {
        var quiz = _context.Questions.SingleOrDefault(x => x.Id == id);
        return _mapper.Map<EditQuestion>(quiz);
    }

    public List<QuestionViewModel> GetAll()
    {
        return _mapper.Map<List<QuestionViewModel>>(_context.Questions.Include(x=>x.Quiz).ToList());
    }
}