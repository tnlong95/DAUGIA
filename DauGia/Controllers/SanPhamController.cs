using DauGia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham/byCat
        public ActionResult ByCat(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var ctx = new DauGiaEntities())
            {
                var list = ctx.SanPhams.Where(n => n.MaTheLoai == id).ToList();
                return View(list);
            }
        }

        public ActionResult NamSanPhamGiaCaoNhat()
        {
            using (DauGiaEntities ctx = new DauGiaEntities())
            {
                var list = ctx.SanPhams.Where(x => x.DaBan == false)
                    .OrderBy(n => n.Gia).Take(5).ToList();
                return PartialView("NamSanPhamGiaCaoNhat", list);
            }
        }

        public ActionResult NamSanPhamCoNhieuLuoDauGiaNhat()
        {
            using (DauGiaEntities ctx = new DauGiaEntities())
            {
                var list = ctx.GiaoDiches.Where(x => x.ThangCuoc == false)
                    .GroupBy(n => n.MaSanPham)
                    .Select(x => new { MaSanPham = (int)x.Key,Count = x.Count() })
                    .OrderByDescending(x => x.MaSanPham).Take(5).ToList();
                var lstSanPham = new List<SanPham>();
                foreach (var item in list)
                {
                    var sanpham = ctx.SanPhams.SingleOrDefault(x => x.MaSanPham == item.MaSanPham);
                    lstSanPham.Add(sanpham);
                }
                return PartialView("NamSanPhamCoNhieuLuoDauGiaNhat", lstSanPham);
            }
        }
        public ActionResult NamSanPhamCoNgayGanHetHan()
        {
            using (DauGiaEntities ctx = new DauGiaEntities())
            {

                var list = ctx.SanPhams.Where(x => x.DaBan == false)
                    .OrderBy(x => x.NgayKetThuc).Take(5).ToList();
                return PartialView("NamSanPhamCoNhieuLuoDauGiaNhat", list);
            }
        }
    }
}