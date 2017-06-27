using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class LoginModel
    {
        public string TenDN { get; set; }
        public string Mk { get; set; }
        public bool Remember { get; set; }
    }
}