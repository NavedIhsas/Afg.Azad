using _0_FrameWork.Domain;

namespace ShopManagement.Domain.LanguageAgg
{
    public class Language
    {
        public Language(long id, string culture)
        {
            Id = id;
            Culture = culture;
        }
        public long Id { get; private set; }
        public string Culture { get; private set; }
    }

    public interface ILanguageRepository:IRepository<long,Language>
    {
        long GetLanguageCulture(string culture);
    }
}
