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
        // 5 sản phẩm có ra giá nhiều nhất
        //public ActionResult PartialSanPhamRaGiaNhieu(int masp, int giasp, int theloaiId)
        //{
        //    //using (DAMobileEntities ql = new DAMobileEntities())
        //    //{
        //    //    var model = ql.SANPHAMs.
        //    //       Join(ql.SANPHAMCHITIETs,
        //    //       sp => sp.MASP,
        //    //       ct => ct.MASP,
        //    //       (sp, ct) => new SP_CTModel
        //    //       {
        //    //           TLid = (int)sp.MATHELOAI,
        //    //           spid = sp.MASP,
        //    //           nsx_id = (int)sp.MANHASANXUAT,
        //    //           tensp = sp.TENSP,
        //    //           linkanh = sp.Link,
        //    //           SLXem = (int)sp.SoLuotXem,
        //    //           ngay = (DateTime)sp.Ngay,
        //    //           gia = (double)ct.Gia,
        //    //           bixoa = (int)sp.bixoa,
        //    //           manhinh = ct.ManHinh,
        //    //           hdh = ct.HeDieuHanh,
        //    //           cpu = ct.CPU,
        //    //           camsau = ct.CamSau,
        //    //           sim = ct.TheSim,
        //    //           pin = ct.DungLuongPin,
        //    //           camtruoc = ct.CamTruoc,
        //    //           bonhotrong = ct.BoNhoTrong,
        //    //           chucnangkhac = ct.ChucNangKhac,
        //    //           ram = ct.Ram,
        //    //           hotrothenho = ct.HoTroTheNho
        //    //       }).Where(p => p.TLid == theloaiId && p.gia <= giasp && p.spid != masp && p.bixoa == 0)
        //    //       .OrderByDescending(i => i.gia).Take(4).ToList();
        //    //    return PartialView(model);
        //    //}
        //}
        //// 5 sản phẩm có giá cao nhất
        //public ActionResult PartialSanPhamRaGiaCaoNhat()
        //{

        //}
        //// 5 sản phẩm có gần kết thúc
        //public ActionResult PartialSanPhamGanKetThuc()
        //{

        //}
        // GET: /SanPham/
        //[HttpGet]

        //public ActionResult TatCaSanPham(int? id, int curPage = 1, int id_nsx = 0)
        //{
        //    if (curPage < 1)
        //    {
        //        curPage = 1;
        //    }
        //    using (DAMobileEntities ql = new DAMobileEntities())
        //    {

        //        if (id == null)
        //        {
        //            ViewBag.catId = 0;
        //        }
        //        else
        //        {
        //            ViewBag.catId = id;// the loaik
        //        }
        //        ViewBag.nsxId = id_nsx;
        //        var query = ql.SANPHAMs.
        //            Join(ql.SANPHAMCHITIETs,
        //            sp => sp.MASP,
        //            ct => ct.MASP,
        //            (sp, ct) => new SP_CTModel
        //            {
        //                TLid = (int)sp.MATHELOAI,
        //                spid = sp.MASP,
        //                bixoa = (int)sp.bixoa,
        //                nsx_id = (int)sp.MANHASANXUAT,
        //                tensp = sp.TENSP,
        //                linkanh = sp.Link,
        //                gia = (double)ct.Gia,
        //                manhinh = ct.ManHinh,
        //                hdh = ct.HeDieuHanh,
        //                cpu = ct.CPU,
        //                camsau = ct.CamSau,
        //                sim = ct.TheSim,
        //                soluong = (int)ct.Soluong,
        //                pin = ct.DungLuongPin,
        //            }).Where(sp => sp.TLid == id | sp.nsx_id == id_nsx && sp.bixoa == 0);

        //        int n = query.Count();
        //        ViewBag.MaNhaSanXuat = id_nsx;
        //        int nPages = n / 12;

        //        if (n % 12 > 0)
        //        {
        //            nPages++;
        //            ViewBag.NextCuoi = n / 12 + 1;
        //        }
        //        ViewBag.Pages = nPages;
        //        ViewBag.curPage = curPage;
        //        // neu trang = 1 thi k cho 
        //        if (curPage < 1)
        //        {
        //            ViewBag.PrevPage = 1;
        //        }
        //        else
        //        {
        //            ViewBag.PrevPage = curPage - 1;
        //        }
        //        ViewBag.NextPage = curPage + 1;
        //        int nSkip = (curPage - 1) * 12;
        //        var list = query
        //            .OrderBy(p => p.spid)
        //            .Skip(nSkip).Take(12)
        //            .ToList();
        //        return View(list);
        //        if (list.Count < 1)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }

        //}
        //
        // GET: /SanPham/sanphamchitiet
        //[HttpGet]
        //public ActionResult SanPhamChiTiet(int? spid_x)
        //{
        //    if (spid_x.HasValue == false)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    using (DAMobileEntities ql = new DAMobileEntities())
        //    {
        //        SANPHAM sp_updata = ql.SANPHAMs.First(p => p.MASP == spid_x);
        //        sp_updata.SoLuotXem = sp_updata.SoLuotXem + 1;
        //        ql.SaveChanges();
        //        var model = ql.SANPHAMs.
        //            Join(ql.SANPHAMCHITIETs,
        //            sp => sp.MASP,
        //            ct => ct.MASP,
        //            (sp, ct) => new SP_CTModel
        //            {
        //                TLid = (int)sp.MATHELOAI,
        //                spid = sp.MASP,
        //                nsx_id = (int)sp.MANHASANXUAT,
        //                tensp = sp.TENSP,
        //                linkanh = sp.Link,
        //                SLXem = (int)sp.SoLuotXem,
        //                ngay = (DateTime)sp.Ngay,
        //                gia = (double)ct.Gia,
        //                manhinh = ct.ManHinh,
        //                hdh = ct.HeDieuHanh,
        //                cpu = ct.CPU,
        //                camsau = ct.CamSau,
        //                sim = ct.TheSim,
        //                pin = ct.DungLuongPin,
        //                camtruoc = ct.CamTruoc,
        //                bonhotrong = ct.BoNhoTrong,
        //                chucnangkhac = ct.ChucNangKhac,
        //                ram = ct.Ram,
        //                soluong = (int)ct.Soluong,
        //                hotrothenho = ct.HoTroTheNho
        //            }).Where(a => a.spid == spid_x).FirstOrDefault();
        //        return View(model);
        //    }
        //}

        //[HttpGet]
        //public 
    }
}