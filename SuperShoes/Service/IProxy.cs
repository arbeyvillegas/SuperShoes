using SuperShoes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Service
{
    interface IProxy
    {
        Task<ArticleRetrieveResult> GetArticles();
        
        Task<ArticleRetrieveResult> GetArticle(int id);

        Task<Result> PutArticle(Article article);

        Task<Result> PostArticle(Article article);

        Task<Result> DeleteArticle(int id);

        Task<ArticleRetrieveResult> GetArticlesByStoreId(int storeId);

        Task<StoreRetrieveResult> GetStores();

        Task<StoreRetrieveResult> GetStore(int id);

        Task<Result> PutStore(Store store);

        Task<Result> PostStore(Store store);

        Task<Result> DeleteStore(int id);
    }
}
