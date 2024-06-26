using System.Collections.Generic;
using Shop.Management.Application.Contract.Language;
using ShopManagement.Domain.LanguageAgg;

namespace ShopManagement.Application
{
    public class LanguageApplication : ILanguageApplication
    {
        private readonly ILanguageRepository _language;

        public LanguageApplication(ILanguageRepository language)
        {
            _language = language;
        }

        public string GetLangCulture(long id)
        {
            return _language.GetById(id)?.Culture;
        }

        public GetLang GetLanguage(long id)
        {
            var result = _language.GetById(id);
            return new GetLang() { Id = result.Id, Culture = result.Culture };
        }

        public long GetLanguageCulture(string culture)
        {
            return _language.GetLanguageCulture(culture);
        }
    }
}
