using Lab06.App_Start;
using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06.Controllers
{
    public class StoreController : Controller
    {
        MyDbContext context = new MyDbContext();

        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult DeleteStore(int id)
        {
            try
            {
                Store storeToDelete = new Store { id = id };
                context.Stores.Attach(storeToDelete);
                context.Stores.Remove(storeToDelete);
                context.SaveChanges();
                return RedirectToAction("Index", "Store");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Probably you tried to Delete From DB with the wrong id, nothing was deleted" });
            }
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var nameFromForm = Request.Form["storeName"];

            if (nameFromForm != null)
            {
                string name = nameFromForm.ToString();
                if (name.Length != 0)
                {
                    AddToDB(name);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert Store's name to insert into DB" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert Store's name to insert into DB" });
            }
            return RedirectToAction("Index", "Store");
        }

        private void AddToDB(string name)
        {
            Store store = new Store { name = name };
            context.Stores.Add(store);
            context.SaveChanges();
        }


        [HttpGet]
        public ActionResult UpdateStore(int id)
        {
            Store store = context.Stores.Where(s => s.id == id).First();
            return View(store);
        }

        [HttpPost]
        public ActionResult UpdateStore(Store store)
        {
            try
            {
                var dbModel = context.Stores.Where(s => s.id == store.id).First();
                dbModel.name = store.name;
                context.SaveChanges();
                return RedirectToAction("Index", "Store");
            }
            catch (Exception e)
            {
                throw new Exception("Store with id = " + store.id + " was not found!");
            }
        }
    }
}