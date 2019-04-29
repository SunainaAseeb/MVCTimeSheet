using MVCTimeSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCTimeSheet.Controllers
{
    public class TimeDetailsController : Controller
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


        public IEnumerable<TimeDetails> GetTimeDetails()
        {
            IEnumerable<TimeDetails> timeDetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/");

                var responseTask = client.GetAsync("api/TimeDetails");
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
        public IEnumerable<Task> GetTasks()
        {
            IEnumerable<Task> Tasks = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/");

                var responseTask = client.GetAsync("api/Tasks");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Task>>();
                    readTask.Wait();
                    Tasks = readTask.Result;
                }

            }
            return Tasks;

        }

        // GET: TimeDetails
        public ActionResult Index()
        {
            IEnumerable<Employee> Employees = GetAllEmployees();
            return View(Employees);
        }
        public ActionResult TimeSheet(int id)
        {
            IEnumerable<TimeDetails> timeDetails = GetTimeDetails();
            IEnumerable<Employee> Employees = GetAllEmployees();
            IEnumerable<Task> Tasks = GetTasks();
            ViewBag.Emp = Employees.Select(p=>p.Id == id);
            ViewBag.Time = timeDetails;
            ViewBag.Tasks = Tasks;

            return View();
        }
    }
}