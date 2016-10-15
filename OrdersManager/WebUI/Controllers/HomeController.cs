using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Businesslogic;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderManager _orderManager;

        public HomeController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}