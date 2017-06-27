using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class Profile
    {
        public int MaTK { get; set; }
        public string NameNew { get; set; }
        public string EmailNew { get; set; }
        public string Oldpass { get; set; }
        public string NewPass { get; set; }
    }
}