using SuperShoes.Domain.Business;
using SuperShoes.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperShoes.Services.Controllers
{
    public class StoresController : ApiController
    {
        public StoreRetrieveResult Get()
        {
            StoreRetrieveResult result = new StoreRetrieveResult()
            {
                Success=true
            };
            try
            {
                StoreBusiness storeBusiness = new StoreBusiness();
                result.Stores = storeBusiness.GetAll();
                result.Total_Elements = result.Stores.Count;

                if (result.Total_Elements == 0)
                {
                    result.Error_Code = 400;
                    result.Success = false;
                    result.Error_Msg = "Record not found";
                }
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }

        public StoreRetrieveResult GetById(int id)
        {
            StoreRetrieveResult result = new StoreRetrieveResult()
            {
                Success = true
            };
            try
            {
                StoreBusiness storeBusiness = new StoreBusiness();
                result.Stores = storeBusiness.Get(id);
                result.Total_Elements = result.Stores.Count;

                if (result.Total_Elements == 0)
                {
                    result.Error_Code = 400;
                    result.Success = false;
                    result.Error_Msg = "Record not found";
                }
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }



        public Result Put([FromBody] Store store)
        {
            Result result = new Result()
            {
                Success = true
            };
            try
            {
                StoreBusiness storeBusiness = new StoreBusiness();
                storeBusiness.Save(store);
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }

        public Result Post([FromBody] Store store)
        {
            Result result = new Result()
            {
                Success = true
            };
            try
            {
                StoreBusiness storeBusiness = new StoreBusiness();
                storeBusiness.Update(store);
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }

        public Result Delete([FromUri(Name="id")] int id)
        {
            Result result = new Result()
            {
                Success = true
            };
            try
            {
                StoreBusiness storeBusiness = new StoreBusiness();
                storeBusiness.Delete(id);
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }
    }
}
