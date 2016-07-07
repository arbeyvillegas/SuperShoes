using Newtonsoft.Json;
using SuperShoes.Model;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SuperShoes.Service
{
    public class ProxyJson : IProxy
    {


        public async Task<ArticleRetrieveResult> GetArticles()
        {
            ArticleRetrieveResult articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("services/articles");
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<ArticleRetrieveResult>(resultString);
                }
                else
                {
                    articleResult = new ArticleRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        public async Task<ArticleRetrieveResult> GetArticle(int id)
        {
            ArticleRetrieveResult articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(string.Format("services/articles/getbyid/{0}", id));
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<ArticleRetrieveResult>(resultString);
                }
                else
                {
                    articleResult = new ArticleRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        public async Task<Result> PutArticle(Model.Article article)
        {
            Result articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                var mediaType = new MediaTypeHeaderValue("application/json");
                string content = JsonConvert.SerializeObject(article);
                StringContent stringContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync("services/articles", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<Result>(resultString);
                }
                else
                {
                    articleResult = new ArticleRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        public async Task<Result> PostArticle(Article article)
        {
            Result articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                var mediaType = new MediaTypeHeaderValue("application/json");
                string content = JsonConvert.SerializeObject(article);
                StringContent stringContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("services/articles", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<Result>(resultString);
                }
                else
                {
                    articleResult = new ArticleRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        public async Task<Result> DeleteArticle(int id)
        {
            Result articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(string.Format("services/articles/delete/{0}", id));
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<Result>(resultString);
                }
                else
                {
                    articleResult = new Result()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        public async Task<ArticleRetrieveResult> GetArticlesByStoreId(int storeId)
        {
            ArticleRetrieveResult articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(string.Format("services/articles/stores/{0}", storeId));
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<ArticleRetrieveResult>(resultString);
                }
                else
                {
                    articleResult = new ArticleRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        public async Task<StoreRetrieveResult> GetStores()
        {
            StoreRetrieveResult storeResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("services/stores");
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    storeResult = JsonConvert.DeserializeObject<StoreRetrieveResult>(resultString);
                }
                else
                {
                    storeResult = new StoreRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return storeResult;
        }

        public async Task<StoreRetrieveResult> GetStore(int id)
        {
            StoreRetrieveResult storeResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(string.Format("services/stores/getbyid/{0}", id));
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    storeResult = JsonConvert.DeserializeObject<StoreRetrieveResult>(resultString);
                }
                else
                {
                    storeResult = new StoreRetrieveResult()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return storeResult;
        }

        public async Task<Result> PutStore(Model.Store store)
        {
            Result storeResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                var mediaType = new MediaTypeHeaderValue("application/json");
                string content = JsonConvert.SerializeObject(store);
                StringContent stringContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync("services/stores", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    storeResult = JsonConvert.DeserializeObject<Result>(resultString);
                }
                else
                {
                    storeResult = new Result()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return storeResult;
        }

        public async Task<Result> PostStore(Model.Store store)
        {
            Result storeResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                var mediaType = new MediaTypeHeaderValue("application/json");
                string content = JsonConvert.SerializeObject(store);
                StringContent stringContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("services/stores", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    storeResult = JsonConvert.DeserializeObject<Result>(resultString);
                }
                else
                {
                    storeResult = new Result()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return storeResult;
        }

        public async Task<Result> DeleteStore(int id)
        {
            Result articleResult = null;
            using (HttpClient httpClient = this.CreateHttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(string.Format("services/stores/delete/{0}", id));
                if (response.IsSuccessStatusCode)
                {
                    String resultString = await response.Content.ReadAsStringAsync();
                    articleResult = JsonConvert.DeserializeObject<Result>(resultString);
                }
                else
                {
                    articleResult = new Result()
                    {
                        Success = false,
                        Error_Msg = response.ReasonPhrase
                    };
                }
            }
            return articleResult;
        }

        private HttpClient CreateHttpClient()
        {

            string webApiAddress = ConfigurationManager.AppSettings.Get("WebApiAddress");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(webApiAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}