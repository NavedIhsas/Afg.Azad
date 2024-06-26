namespace Afg.Azad.UnQuery.Contract
{
    public interface ILanguageQuery
    {
        string GetLanguage(long id);
        long GetLanguageId(string lang);
    }
}
