using Lab06.App_Start;
using Lab6.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab06.Controllers
{
    public class CarrierController : Controller
    {
        MyDbContext context = new MyDbContext();

        public ActionResult Index()
        {
            return View(context);
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var nameFromForm = Request.Form["carrierName"];

            if (nameFromForm != null)
            {
                string name = nameFromForm.ToString();
                if (name.Length != 0)
                {
                    AddToDB(name);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = "Please insert Carrier's name to insert into DB" });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert Carrier's name to insert into DB" });
            }
            return RedirectToAction("Index", "Carrier");
        }

        private void AddToDB(string name)
        {
            Carrier carrier = new Carrier { name = name };
            context.Carriers.Add(carrier);
            context.SaveChanges();
        }

        [HttpGet]
        public ActionResult UpdateCarrier(int id)
        {
            Carrier carrier = context.Carriers.Where(c => c.id == id).First();
            if(carrier == null)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Please insert id, Carrier's name to update" });
            }
            return View(carrier);
        }

        [HttpPost]
        public ActionResult UpdateCarrier(Carrier carrier)
        {
            try
            {
                var dbModel = context.Carriers.Where(c => c.id == carrier.id).First();
                dbModel.name = carrier.name;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Carrier with id = " + carrier.id + " was not found!");
            }
            return RedirectToAction("Index", "Carrier");
        }

        [HttpGet]
        public ActionResult DeleteCarrier(int id)
        {
            Carrier carrierToDelete = new Carrier { id = id };
            context.Carriers.Attach(carrierToDelete);
            context.Carriers.Remove(carrierToDelete);
            context.SaveChanges();
            return RedirectToAction("Index", "Carrier");
        }
    }
}