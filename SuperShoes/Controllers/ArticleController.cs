using Microsoft.Practices.ServiceLocation;
using SuperShoes.Model;
using SuperShoes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SuperShoes.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        public async Task<ActionResult> Index()
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            ArticleRetrieveResult result = await proxy.GetArticles();

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Error_Msg;
            }

            return View(result.Articles);
        }

        public async Task<ActionResult> ArticlesByStore(int storeId)
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            ArticleRetrieveResult result = await proxy.GetArticlesByStoreId(storeId);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Error_Msg;
                return RedirectToAction("Index", "Store");
            }
            else
            {
                if (result.Articles.Count > 0)
                {
                    ViewBag.StoreName = result.Articles.FirstOrDefault().StoreName;
                }
            }

            return View(result.Articles);
        }



        //
        // GET: /Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Article/Create
        public async Task<ActionResult> Create()
        {
            Article article = new Article();
            await this.PrepareCreateArticle();
            return View(article);
        }

        private async Task<Boolean> PrepareCreateArticle()
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            StoreRetrieveResult result = await proxy.GetStores();
            if (result.Success)
            {
                ViewData["Stores"] = new SelectList(result.Stores, "Id", "Name");
            }
            return result.Success;
        }

        //
        // POST: /Article/Create
        [HttpPost]
        public async Task<ActionResult> Create(Article model)
        {
            try
            {
                IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
                Result result = await proxy.PutArticle(model);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = result.Error_Msg;
                    await this.PrepareCreateArticle();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        //
        // GET: /Article/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            ArticleRetrieveResult articleRetrieveResult = await proxy.GetArticle(id);
            if (articleRetrieveResult.Success && articleRetrieveResult.Total_Elements > 0)
            {
                Article article = articleRetrieveResult.Articles.First<Article>();
                await this.PrepareCreateArticle();
                return View(article);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Article/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Article model)
        {
            try
            {
                IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
                Result result = await proxy.PostArticle(model);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = result.Error_Msg;
                    await this.PrepareCreateArticle();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        //
        // GET: /Article/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            Result result = await proxy.DeleteArticle(id);
            return RedirectToAction("Index");
        }
    }
}
