using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[HandleError]

    public class JsonDemoController : Controller
    {
        // GET: JsonDemo
        public ActionResult Index()
        {
            var x = TempData["Greetings"];
             Person person = new Person();


            var y = TempData["Greetings"];
            Student student = new Student();
            return View();
        }
       

        [HttpPost]
        public JsonResult GetPersonData(string PersonJson)
        {

            var js = new JavaScriptSerializer();
            var persons = js.Deserialize<Person[]>(PersonJson);

            return Json(persons, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonData()
        {
            List<Person> list = new List<Person>()
            {
                new Person() {Description="Student", Name="Mary"},
                new Person(){ Description="Teacher", Name="Ryan"}
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public FileResult Index_File()
        {
            return File("~/Web.Config", "text");
        }

        public FileResult Index_File1()
        {
            return File(Url.Content("~/Web.Config"), "text");
        }

        public FileResult DownloadFile()
        {
            //Build the File Path.
            string path = Server.MapPath("~/Files/") + "Test.txt";

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", "Test1.txt");
        }
    }
}