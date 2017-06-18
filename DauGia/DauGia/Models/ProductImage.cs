using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class ProductImage
    {
        public virtual int ProductId { get; set; }
        public virtual string Img { get; set; }
    }
}