using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.Common;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class PController : Controller
    {
        private readonly DLSalesOrders _soRepository;
        public PController()
        {
            _soRepository = new DLSalesOrders();
        }
        // GET: P
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PI(string N)
        {
            SalesOrders so = _soRepository.GetSalesOrderDetails(N, true, true);
            return View("_InvoicePrint", so);
        }
    }
}