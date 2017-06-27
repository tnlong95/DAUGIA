using DauGia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Helper
{
    public class CurrentContext
    {
        public static bool IsLogged()
        {
            if (HttpContext.Current.Session["IsLogin"] == null)
            {
                HttpContext.Current.Session["IsLogin"] = 0;
            }

            if ((int)HttpContext.Current.Session["IsLogin"] == 1)
                return true;
            // kiểm tra cookie rỗng k.
            // nếu không rỗng tái tạo lại session và xem như đã đăng nhập

            if (HttpContext.Current.Response.Cookies["UserName"] != null)
            {
                string username = HttpContext.Current.Request.Cookies["UserName"].Value;

                using (DauGiaEntities ql = new DauGiaEntities())
                {
                    NguoiDung tk = ql.NguoiDung.
                        Where(q => q.TaiKhoan == username).
                        FirstOrDefault();
                    if (tk != null)
                    {

                        HttpContext.Current.Session["CurUser"] = tk;
                        HttpContext.Current.Session["IsLogin"] = 1;
                        return true;
                    }
                }
            }
            return false;
        }
        public static NguoiDung CurUser()
        {
            return (NguoiDung)HttpContext.Current.Session["CurUser"];
        }
        public static void Destroy()
        {
            HttpContext.Current.Session["IsLogin"] = 0;
            HttpContext.Current.Session["CurUser"] = null;
            HttpContext.Current.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}