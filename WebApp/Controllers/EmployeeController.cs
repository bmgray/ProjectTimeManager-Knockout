using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    //[RoutePrefix("employees")]
    public class EmployeeController : Controller
    {
        // GET: Employees List
        //[Route("list")]
        public ActionResult ListEmployees()
        {
            return View("EmployeesList");
        }
    }
}