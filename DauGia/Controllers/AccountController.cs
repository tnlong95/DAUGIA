using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DauGia.Data;
using DauGia.Helper;
using DauGia.Model;
using DauGia.Fitters;


namespace DauGia.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        // Post/Accout/Login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
               string encPW = StringUtils.Md5(model.Mk);
                NguoiDung tk = ql.NguoiDung.
                    Where(u => u.TaiKhoan == model.TenDN && u.MatKhau == encPW)
                    .FirstOrDefault();
                if (tk == null)
               {
                   ViewBag.Err = "Xin vui lòng kiểm tra lại thông tin đăng nhập!";
                   return View(model);
               }
               else
               {
                   Session["IsLogin"] = 1;
                   Session["CurUser"] = tk;
                    if (model.Remember)// khi đã đăng nhập
                   {

                       Response.Cookies["UserName"].Value = TenNguoiDung;
                       Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                   }
                   if (tk.PhanQuyen == 1)
                    {
                       return RedirectToAction("Index", "Home");
                   }
                   else
                   {
                       return RedirectToAction("Index", "Home");
                   }
               }
           }
        }
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }
        // Post: /Account/Register
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Error = "Error Captcha";
                return View(model);
            }
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                int n = ql.NguoiDung
                    .Where(us => us.TaiKhoan == model.Ten)
                    .Count();
                if (n == 1)
                {
                    ViewBag.Error = model.Ten + " đã có trong hệ thống";
                    return View(model);
                }
            }
            ViewBag.TenDangNhap = model.Ten;
            NguoiDung tk = new NguoiDung
            {
                TaiKhoan = model.Ten,
                MatKhau = StringUtils.Md5(model.MK),
                Email = model.Email,
                TenNguoiDung = model.FullName,
                PhanQuyen =1,
            };
            using (DauGiaEntities ctx = new DauGiaEntities())
            {

                ctx.Users.Add(tk);
                ctx.SaveChanges();
                ModelState.Clear();
            }

           return RedirectToAction("Login", "Account");
        }
        // Post: /Account/LogOut
        [HttpPost]
        public ActionResult LogOut()
        {
            CurrentContext.Destroy();
            return RedirectToAction("Login", "Account");
        }
        //
        //Get: /Account/profile
        [CheckLogin]
        public ActionResult Profile()
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                NguoiDung tk = CurrentContext.CurUser();
                string ten = tk.TaiKhoan;
                var model = ql.NguoiDung.Where(p => p.TaiKhoan== ten).FirstOrDefault();
                return View(model);
            }
        }
        [CheckLogin]
        [HttpPost]
         public ActionResult profilepass(Profile pr)
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                string encPW = StringUtils.Md5(userUpdate.PasswordOld);
                NguoiDung tk = ql.NguoiDung.Where(p => p.MaNguoiDung == pr.MaTK).FirstOrDefault();
                if (tk.MatKhau == encPW)
                {
                    tk.MatKhau = StringUtils.Md5(pr.NewPass).ToString();
                    tk.Email = pr.EmailNew;
                    tk.TenNguoiDung = pr.NameNew;
                    ql.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error =" Cap nhat that bai!";
                    return View(tk);
                }
            }
        }
    }
}