using Shop.Management.Application.Contract.Language;

namespace CommentManagement.infrastructure.ShopAcl.Lang
{
    public interface ICommentLanguage
    {
        string GetLanguage(long id);
        long GetLanguageId(string lang);
    }

    public class CommentLanguage : ICommentLanguage
    {
        private readonly ILanguageApplication _application;

        public CommentLanguage(ILanguageApplication application)
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
