using DauGia.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            return View();
        }
        
        public ActionResult ProductDetail()
        {
            return View();
        }
       
        public ActionResult PartialDanhSachSanPham()
        {
            var lstKetQua = new List<SanPhams>();
            using (DauGiaEntities ctx = new DauGiaEntities())
            {
                var lstSanPham = ctx.SanPhams.where(x => x.DaDuyet == false).ToList();
                foreach (var item in lstSanPham)
                {
                    var danhmuc = ctx.DanhMucs.SingleOrDefault(x => x.MaTheLoai == item.MaTheLoai.Value);
                    var nguoiDung = ctx.NguoiDungs.SingleOrDefault(x => x.MaNguoiDung = item.MaNguoiDung.Value);
                    var sanpham = new SanPhams()
                    {
                        MaSanPham = item.MaSanPham,
                        Gia = item.Gia,
                        Hinhanh1 = item.HinhAnh1,
                        HinhAnh2 = item.HinhAnh2,
                        HinhAnh3 = item.HinhAnh3,
                        NgayBatDau = item.NgayBatDau,
                        NgayKetThuc = item.NgayKetThuc,
                        TenSanPham = item.TenSanPham,
                        LoaiSanPham = item.DanhMuc,
                        NguoiDung = nguoiDung
                    };
                    lstKetQua.Add(sanpham);
                }
                lstKetQua.OrderBy(x => x.NgayBatDau).ToList();
                return partialView("DanhSachSanPham", lstKetQua);

                }
            }
        public ActionReSult DuyetSanPham (int id)
        {
            using (DauGiaEntities ctx = new DauGiaEntities())
            {
                SanPham sp = ctx.SanPhams.Single(c => c.MaSanPham == id);
                if (sp != null)
                    sp.DaDuyet = true;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index", "Manager");
        }
    }
}