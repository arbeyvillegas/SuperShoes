using Microsoft.Practices.ServiceLocation;
using SuperShoes.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Domain.Business
{
    public class StoreBusiness
    {
        public void Save(SuperShoes.Model.Store store)
        {
            Store storeDataModel = this.ConvertModelToDataEntity(store);
            IRepository<Store> repository = ServiceLocator.Current.GetInstance<IRepository<Store>>();
            repository.Add(storeDataModel);
            repository.SaveChanges();
        }

        public void Update(SuperShoes.Model.Store store)
        {
            Store storeDataModel = this.ConvertModelToDataEntity(store);
            IRepository<Store> repository = ServiceLocator.Current.GetInstance<IRepository<Store>>();
            repository.Update(storeDataModel);
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            IRepository<Store> repository = ServiceLocator.Current.GetInstance<IRepository<Store>>();
            Store store = repository.Get(id);
            repository.Delete(store);
            repository.SaveChanges();
        }

        public ICollection<SuperShoes.Model.Store> GetAll()
        {
            IRepository<Store> repository = ServiceLocator.Current.GetInstance<IRepository<Store>>();
            IOrderedEnumerable<Store> storeDataList = repository.GetAll(s => s.name);
            return this.ConvertListDataEntityToListModel(storeDataList);
        }

        public ICollection<SuperShoes.Model.Store> Get(int id)
        {
            IRepository<Store> repository = ServiceLocator.Current.GetInstance<IRepository<Store>>();
            IEnumerable<Store> storeDataList = repository.GetSome(s => s.id == id);
            return this.ConvertListDataEntityToListModel(storeDataList);
        }


        private Store ConvertModelToDataEntity(SuperShoes.Model.Store store)
        {
            Store storeDataEntity = new Store()
                {
                    id = store.Id,
                    name = store.Name,
                    address = store.Address
                };

            return storeDataEntity;
        }

        private ICollection<SuperShoes.Model.Store> ConvertListDataEntityToListModel(IEnumerable<Store> storeDataModelList)
        {
            ICollection<SuperShoes.Model.Store> storeList = (from Store store in storeDataModelList
                                                             select new SuperShoes.Model.Store()
                                                             {
                                                                 Id = store.id,
                                                                 Name = store.name,
                                                                 Address = store.address
                                                             }).ToList();
            return storeList;
        }


    }
}
