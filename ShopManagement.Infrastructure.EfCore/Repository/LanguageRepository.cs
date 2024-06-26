using System.Linq;
using _0_FrameWork.Domain.Infrastructure;
using ShopManagement.Domain.LanguageAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class LanguageRepository:RepositoryBase<long,Language>,ILanguageRepository
    {
        private readonly ShopContext _context;
        public LanguageRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public long GetLanguageCulture(string culture)
        {
            var id = _context.Languages.FirstOrDefault(x => x.Culture.Contains(culture.ToLower().Trim()))?.Id;
            if (id != null)
                return (long)id;
            return 0;
        }
    }
}
