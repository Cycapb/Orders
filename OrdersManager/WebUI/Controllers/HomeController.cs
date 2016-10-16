using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Businesslogic;
using Domain;
using Paginator.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IPageCreator _pageCreator;
        private readonly int _itemsPerPage;

        public HomeController(IOrderManager orderManager, IPageCreator pageCreator)
        {
            _orderManager = orderManager;
            _pageCreator = pageCreator;
            _itemsPerPage = 10;
        }

        public async Task<ActionResult> Index()
        {
            var items = await _orderManager.GetOrders();
            return View(items.Take(10));
        }

        public async Task<ActionResult> ListByDate(DateTime dtBeg, DateTime dtEnd, int page = 1)
        {
            var items = (await _orderManager.GetOrders()).Where(x => x.OrderDate >= dtBeg && x.OrderDate <= dtEnd).ToList();
            var orders = items
                .Skip((page - 1) * _itemsPerPage)
                .Take(_itemsPerPage)
                .ToList();
            if (Session != null){ Session["Orders"] = items; }
            ViewBag.PageCreator = _pageCreator;
            ViewBag.PagingInfo = new PagingInfo()
            {
                ItemsPerPage = _itemsPerPage,
                CurrentPage = page,
                TotalItems = items.Count
            };
            ViewBag.DtBeg = dtBeg;
            ViewBag.DtEnd = dtEnd;
            return PartialView("_ListByDate", orders);
        }

        public async Task Unload()
        {
            if (Session != null)
            {
                var orders = (IEnumerable<OrderToUnload>)Session["Orders"];
                await _orderManager.UnloadToExcel(orders);
            }
        }
    }
}