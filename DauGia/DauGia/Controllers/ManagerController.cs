using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class ManagerController : BaseController
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagerUser()
        {
            return View();
        }
        public ActionResult ManagerTicket()
        {
            return View();
        }
    }
}