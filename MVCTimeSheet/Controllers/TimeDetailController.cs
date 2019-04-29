using MVCTimeSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCTimeSheet.Controllers
{
    public class TimeDetailController : Controller
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            IEnumerable<Employee> Employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/");

                var responseTask = client.GetAsync("api/v1/employee/getall");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();
                    Employees = readTask.Result;
                }

            }
            return Employees;

        }


        public IEnumerable<TimeDetails> GetTimeDetails(string code)
        {
            IEnumerable<TimeDetails> timeDetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/");


                string url = "api/TimeDetails/" + code;
                
                    var responseTask = client.GetAsync(url);
                    responseTask.Wait();
                
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TimeDetails>>();
                    readTask.Wait();
                    timeDetails = readTask.Result;
                }

            }
            return timeDetails;

        }
       

        // GET: TimeDetail
        public ActionResult Index()
        {
            IEnumerable<Employee> emps = GetAllEmployees();
            return View(emps);
        }
        
        public ActionResult TimeSheet( string code)
        {
            
            IEnumerable<TimeDetails> ts = GetTimeDetails(code);
            return View(ts);
        }
        // GET: TimeDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
