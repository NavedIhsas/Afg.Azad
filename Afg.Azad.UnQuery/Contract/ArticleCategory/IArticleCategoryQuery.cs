using System.Collections.Generic;

namespace Afg.Azad.UnQuery.Contract.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryQueryModel> GetAll();
        List<ArticleCategoryQueryModel> GetTen();
    }
}