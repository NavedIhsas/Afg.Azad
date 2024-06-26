using Shop.Management.Application.Contract.Language;
using Afg.Azad.UnQuery.Contract;

namespace Afg.Azad.UnQuery.Query
{
    public class LanguageQuery : ILanguageQuery
    {
        private readonly ILanguageApplication _application;

        public LanguageQuery(ILanguageApplication application)
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
