using Shop.Management.Application.Contract.Language;

namespace AccountManagement.Infrastructure.ShopAcl.Lang
{
    public interface ILanguage
    {
        string GetLanguage(long id);
        long GetLanguageId(string lang);
    }

    public class Language : ILanguage
    {
        private readonly ILanguageApplication _application;

        public Language(ILanguageApplication application)
        {
            _application = application;
        }

        public string GetLanguage(long id)
        {
            return _application.GetLangCulture(id);
        }

        public long GetLanguageId(string culture)
        {
            return _application.GetLanguageCulture(culture);
        }
    }
}
