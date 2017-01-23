using DataAccess.Managers;
using DataBridge;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IModelRepository _repo;

        public HomeController()
        {
            // This would be replaced by nInject or another dependency injector, if implemented.
            // We are simply hand-coding this in each Controller. 
            _repo = new DataBridgeModelRepository();
        }
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

            return View();
        }
    }
}