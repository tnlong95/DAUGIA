using DauGia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class NguoiDungController : Controllers
    {
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialDanhSachNguoiDung()
        {
            using (DauGiaEntities ctx = new DauGiaEntities())
            {
                var lstNguoiDung = ctx.NguoiDung.ToList();
                return PartialView("DanhSachNguoiDung", lstNguoiDung);
            }
        }
    }
}