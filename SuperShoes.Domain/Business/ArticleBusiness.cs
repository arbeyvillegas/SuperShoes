using Microsoft.Practices.ServiceLocation;
using SuperShoes.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Domain.Business
{
    public class ArticleBusiness
    {
        public void Save(SuperShoes.Model.Article article)
        {

            Article articleDataModel = this.ConvertModelToDataEntity(article);
            IRepository<Article> repository = ServiceLocator.Current.GetInstance<IRepository<Article>>();
            repository.Add(articleDataModel);
            repository.SaveChanges();
        }

        public void Update(SuperShoes.Model.Article article)
        {
            Article articleDataModel = this.ConvertModelToDataEntity(article);
            IRepository<Article> repository = ServiceLocator.Current.GetInstance<IRepository<Article>>();
            repository.Update(articleDataModel);
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            IRepository<Article> repository = ServiceLocator.Current.GetInstance<IRepository<Article>>();
            Article article = repository.Get(id);
            repository.Delete(article);
            repository.SaveChanges();
        }

        public ICollection<SuperShoes.Model.Article> Get(int id)
        {
            IRepository<Article> repository = ServiceLocator.Current.GetInstance<IRepository<Article>>();
            IEnumerable<Article> articleDataList= repository.GetSome(a => a.id == id);
            return this.ConvertListDataEntityToListModel(articleDataList);
        }

        public ICollection<SuperShoes.Model.Article> GetAll()
        {
            IRepository<Article> repository = ServiceLocator.Current.GetInstance<IRepository<Article>>();
            IOrderedEnumerable<Article> articleDataList = repository.GetAll(s => s.name);
            return this.ConvertListDataEntityToListModel(articleDataList);
        }

        public ICollection<SuperShoes.Model.Article> GetByStoreId(int storeId)
        {
            IRepository<Article> repository = ServiceLocator.Current.GetInstance<IRepository<Article>>();
            IEnumerable<Article> articleDataList = repository.GetSome(a => (a.store_id == storeId), o => o.name);
            return this.ConvertListDataEntityToListModel(articleDataList);
        }


        private Article ConvertModelToDataEntity(SuperShoes.Model.Article article)
        {
            Article articleDataEntity = new Article()
            {
                id = article.Id,
                name = article.Name,
                price = article.Price,
                total_in_shelf = article.TotalInShelf,
                total_in_vault = article.TotalInVault,
                description = article.Description,
                store_id = article.StoreId,
            };

            return articleDataEntity;
        }

        private ICollection<SuperShoes.Model.Article> ConvertListDataEntityToListModel(IEnumerable<Article> articleDataModelList)
        {
            ICollection<SuperShoes.Model.Article> articleList = (from Article article in articleDataModelList
                                                                 select new SuperShoes.Model.Article()
                                                               {
                                                                   Id = article.id,
                                                                   Name = article.name,
                                                                   Description = article.description,
                                                                   Price = article.price,
                                                                   TotalInShelf = article.total_in_shelf,
                                                                   TotalInVault = article.total_in_vault,
                                                                   StoreId = article.Store.id,
                                                                   StoreName = article.Store.name
                                                               }).ToList();
            return articleList;
        }

    }
}
