using DauGia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        public ActionResult List()
        {
            try
            {
                using (DauGiaEntities ctx = new DauGiaEntities())
                {
                    var lstDanhMuc = ctx.DanhMucs.ToList();
                    return PartialView("List",lstDanhMuc);
                }
            }
            catch (Exception ex)
            {
                return PartialView(null);
            }
        }
    }
}