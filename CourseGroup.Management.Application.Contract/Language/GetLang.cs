using System.Collections.Generic;

namespace Shop.Management.Application.Contract.Language
{
    public class GetLang
    {
        public long Id { get; set; }
        public string Culture { get; set; }
    }

    public interface ILanguageApplication
    {
       string GetLangCulture(long id);
       GetLang GetLanguage(long id);
       long GetLanguageCulture(string culture);
    }
}
