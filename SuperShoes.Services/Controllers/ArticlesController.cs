using SuperShoes.Domain.Business;
using SuperShoes.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperShoes.Services.Controllers
{
    public class ArticlesController : ApiController
    {

        public ArticleRetrieveResult Get()
        {
            ArticleRetrieveResult result = new ArticleRetrieveResult()
            {
                Success = true
            };
            try
            {
                ArticleBusiness articleBusiness = new ArticleBusiness();
                result.Articles = articleBusiness.GetAll();
                result.Total_Elements = result.Articles.Count;

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

        public ArticleRetrieveResult GetById([FromUri(Name = "id")]int id)
        {
            ArticleRetrieveResult result = new ArticleRetrieveResult()
            {
                Success = true
            };
            try
            {
                ArticleBusiness articleBusiness = new ArticleBusiness();
                result.Articles = articleBusiness.Get(id);
                result.Total_Elements = result.Articles.Count;

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

        public Result Put([FromBody] Article article)
        {
            Result result = new Result()
            {
                Success = true
            };
            try
            {
                ArticleBusiness articleBusiness = new ArticleBusiness();
                articleBusiness.Save(article);
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }


        public Result Post([FromBody] Article article)
        {
            Result result = new Result()
            {
                Success = true
            };
            try
            {
                ArticleBusiness articleBusiness = new ArticleBusiness();
                articleBusiness.Update(article);
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }

        public Result Delete([FromUri(Name = "id")] int id)
        {
            Result result = new Result()
            {
                Success = true
            };
            try
            {
                ArticleBusiness articleBusiness = new ArticleBusiness();
                articleBusiness.Delete(id);
            }
            catch (Exception ex)
            {
                result.Error_Code = 505;
                result.Success = false;
                result.Error_Msg = ex.Message;
            }
            return result;
        }

        [AcceptVerbs("GET")]
        [ActionName("Stores")]
        public ArticleRetrieveResult Stores([FromUri(Name = "id")] int storeId)
        {
            ArticleRetrieveResult result = new ArticleRetrieveResult()
            {
                Success = true
            };
            try
            {
                ArticleBusiness articleBusiness = new ArticleBusiness();
                result.Articles = articleBusiness.GetByStoreId(storeId);
                result.Total_Elements = result.Articles.Count;

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
    }
}
