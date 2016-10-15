using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Businesslogic;
using Domain;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderManager _orderManager;

        public HomeController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public async Task<ActionResult> Index()
        {
            var items = await _orderManager.GetOrders();
            return View(items.Take(10));
        }

        public ActionResult List(int page = 1)
        {
            
            return PartialView();
        }
    }
}