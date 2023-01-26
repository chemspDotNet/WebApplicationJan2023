using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

              Person p = new Person();
           
            
            return View(p);
        }


        [HttpPost]
        public ActionResult Index( Person frm)
        {
            Person p = new Person();
            if(ModelState.IsValid)
            {
                return View("PostPersonData",p);

            }
            return View();
           
        }


        
    }
}