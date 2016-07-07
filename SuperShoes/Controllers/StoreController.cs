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
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public async Task<ActionResult> Index()
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            StoreRetrieveResult result=await proxy.GetStores();
            
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Error_Msg;
            }

            return View(result.Stores);
        }

        //
        // GET: /Store/Create
        public ActionResult Create()
        {

            Store model = new Store();

            return View(model);
        }

        //
        // POST: /Store/Create
        [HttpPost]
        public async Task<ActionResult> Create(Store model)
        {
            try
            {
                IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
                Result result=await proxy.PutStore(model);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = result.Error_Msg;
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        //
        // GET: /Store/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            StoreRetrieveResult storeRetrieveResult = await proxy.GetStore(id);
            if (storeRetrieveResult.Success && storeRetrieveResult.Total_Elements > 0)
            {
                Store store = storeRetrieveResult.Stores.First<Store>();
                return View(store);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Store/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Store model)
        {
            try
            {
                IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
                Result result = await proxy.PostStore(model);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = result.Error_Msg;
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
        // GET: /Store/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            IProxy proxy = ServiceLocator.Current.GetInstance<IProxy>();
            Result result = await proxy.DeleteStore(id);
            return RedirectToAction("Index");
        }
    }
}
