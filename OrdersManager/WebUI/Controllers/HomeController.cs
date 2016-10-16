using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Index()
        {
            var items = await _orderManager.GetOrders();
            return View(items.Take(10));
        }

        public ActionResult List(int page = 1)
        {
            
            return PartialView();
        }

        public async Task<ActionResult> ListByDate(DateTime dtBeg, DateTime dtEnd)
        {
            var items = (await _orderManager.GetOrders()).Where(x => x.OrderDate >= dtBeg && x.OrderDate <= dtEnd);
            return PartialView("_List", items.Take(10));
        }
    }
}