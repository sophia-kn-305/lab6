using Lab06.App_Start;
using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06.Controllers
{
    public class SellerController : Controller
    {

        MyDbContext context = new MyDbContext();

        public ActionResult Index()
        {
            return View(context);
        }

        [HttpGet]
        public ActionResult DeleteSeller(int id)
        {
            try
            {
                Seller p = new Seller { id = id };
                context.Sellers.Attach(p);
                context.Sellers.Remove(p);
                context.SaveChanges();
                return RedirectToAction("Index", "Seller");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Probably you tried to Delete From DB with the wrong id, nothing was deleted" });
            }
        }

      

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var nameFromForm = Request.Form["sellerName"];

            if (nameFromForm != null)
            {
                string name = nameFromForm.ToString();
                if (name.Length != 0)
                {
                    AddToDB(name);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert Seller's name to insert into DB" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert Seller's name to insert into DB" });
            }
            return RedirectToAction("Index", "Seller");
        }

        private void AddToDB(string name)
        {
            Seller seller = new Seller { name = name };
            context.Sellers.Add(seller);
            context.SaveChanges();
        }

        [HttpGet]
        public ActionResult UpdateSeller(int id)
        {
            Seller seller = context.Sellers.Where(s => s.id == id).First();
            return View(seller);
        }

        [HttpPost]
        public ActionResult UpdateSeller(Seller seller)
        {
            try
            {
                var dbModel = context.Sellers.Where(s => s.id == seller.id).First();
                dbModel.name = seller.name;
                context.SaveChanges();

            } catch (Exception e)
            {
                throw new Exception("Seller with id = " + seller.id + " was not found!");
            }
            return RedirectToAction("Index", "Seller");
        }
    }

}
