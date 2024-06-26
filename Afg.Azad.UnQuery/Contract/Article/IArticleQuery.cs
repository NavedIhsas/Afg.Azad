using System.Collections.Generic;

namespace Afg.Azad.UnQuery.Contract.Article
{
    public interface IArticleQuery
    {
        List<LatestArticleQueryModel> LatestArticle();

        PaginationArticlesViewModel GetAllArticles(SearchArticleQueryModel search, List<long> bloggerId,
            List<string> categories,long category, int pageId = 1);

        SinglePageArticleQueryModel GetSingleArticleBy(string slug, string ipAddress);
    }


    public interface INewsQuery
    {
        List<LatestNewsQueryModel> LatestNews();

        PaginationNewsViewModel GetAllNews( int pageId = 1);

        SinglePageNewsQueryModel GetSingleNewsBy(string slug, string ipAddress);
    }
}