using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.DAL;
using WebApplication1.Models;
using BLL_Layer;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        protected List<Employee> employees = new List<Employee>();

        // GET: Employee
        public ActionResult Index()
        {
            // DAL_Layer dal_layer = new DAL_Layer();

            BLL_LayerClass bll = new BLL_LayerClass();
            DataSet ds = bll.GetEmployee_BLL();


            // DataSet   ds = dal_layer.GetEmployees();
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            var val = dr[0];

            var query = from p in dt.AsEnumerable()
                        select new
                        {
                            ID = p.Field<int>("EmpID"),
                            Name = p.Field<string>("Name"),
                            Job = p.Field<string>("JOB"),
                            Salary = p.Field<decimal>("Salary")
                        };

            foreach (var item in query)
            {
                var emp = new Employee
                {
                    EmpId = item.ID,
                    Name = item.Name,
                    Job = item.Job,
                    Salary = item.Salary,
                };
                employees.Add(emp);
                 
               
            }

            //foreach (DataRow row in dt.Rows)
            //{
            //    var emp = new Employee
            //    {
            //        EmpId = Convert.ToInt32(row["EmpId"]),
            //        Name = row["Name"].ToString(),
            //        Job = row["Job"].ToString(),
            //        Salary = Convert.ToInt32(row["Salary"]),
            //    };
            //    employees.Add(emp);
            //}


            return View(employees);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
               var result =  new DAL_Layer().AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}