using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class NguoiDungModel
    {
        public int MaNguoiDung { set; get; }
        public string TenNguoiDung { set; get; }
        public string Email { set; get; }
        public string MatKhau { set; get; }
        public int PhanQuyen { set; get; }
        public string TenDangNhap { set; get; }
    }
}