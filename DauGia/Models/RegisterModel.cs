using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class RegisterModel
    {
        public string Ten { get; set; }

        public string MK { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public int Permisstion { get; set; }
    }
}