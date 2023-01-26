using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("ContactChanged");
        }


        public ActionResult MyFirstMethod()
        {
            Person p = new Person();
            p.Description = "Studnet;";
            p.Name = "Test";

            return View("View123", p);
        }
    }
}