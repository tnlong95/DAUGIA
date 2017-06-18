using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DauGia.Data;
using DauGia.Helper;
using DauGia.Models;
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
                User tk = ql.Users.
                    Where(u => u.Username == model.TenDN && u.Password == encPW)
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

                        Response.Cookies["UserName"].Value = tk.Username;
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                    }
                    if (tk.RoleId == 1)
                    {
                        return RedirectToAction("Index", "HomeAD");
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
       // [CaptchaValidation("CaptchaCode", "ExampleCaptcha")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Error = "Error Captcha";
                return View(model);
            }
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                int n = ql.Users
                    .Where(us => us.Username == model.Ten)
                    .Count();
                if (n == 1)
                {
                    ViewBag.Error = model.Ten + " đã có trong hệ thống";
                    return View(model);
                }
            }
            ViewBag.TenDangNhap = model.Ten;
            User tk = new User
            {
                Username = model.Ten,
                Password = StringUtils.Md5(model.MK),
                Email = model.Email,
               // HoTen = model.FullName,
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
            return RedirectToAction("Index", "Home");
        }
        //
        //Get: /Account/profile
        [CheckLogin]
        public ActionResult Profile()
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                User tk = CurrentContext.CurUser();
                string ten = tk.Username;
                var model = ql.Users.Where(p => p.Username == ten).FirstOrDefault();
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult UpdateUser(UserUpdateModel userUpdate)
        {
            string message = "";
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                User tk = CurrentContext.CurUser();
                string encPW = StringUtils.Md5(userUpdate.PasswordOld);
                if (tk.Password == encPW)
                {
                    tk.Password = StringUtils.Md5(userUpdate.PasswordNew).ToString();
                    tk.Email = userUpdate.Email.ToString();
                    tk.Adress = userUpdate.Address.ToString();
                    ql.SaveChanges();
                    message = "Cập nhật thành công !";
                }
                else
                {
                    message = "Cập cập thất bại!";
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}