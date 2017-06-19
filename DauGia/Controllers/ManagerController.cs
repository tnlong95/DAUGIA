using DauGia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuanLySanPham()
        {
            return View();
        }
        public ActionResult QuanLyNguoiDung()
        {
            return View();
        }
        public ActionResult QuanLyDanhMuc()
        {
            return View();
        }
    }
}