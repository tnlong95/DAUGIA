using DauGia.Data;
using DauGia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class ProductController : BaseController
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

        [HttpGet]
        public JsonResult GetListProduct()
        {
            try
            {
                var result = new List<Models.Product>();
                using (DauGiaEntities ctx = new DauGiaEntities())
                {
                    var lstProduct = ctx.Products.ToList();
                    foreach (var item in lstProduct)
                    {
                        var product = new Models.Product()
                        {
                            Active = item.Active,
                            Id = item.Id,
                            Name = item.Name,
                            Quantity = item.Quantity,
                            Status = item.Status,
                            Type = item.Type,
                            TimeUpdate = item.TimeUpdate

                        };
                        var lstImg = new List<Models.ProductImage>();
                        foreach (var itemImg in item.ProductImages)
                        {
                            var img = new Models.ProductImage()
                            {
                                Img = itemImg.Img,
                                ProductId = itemImg.ProductId
                            };
                            lstImg.Add(img);
                        }
                        product.ListImg = lstImg;
                        result.Add(product);
                    }
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}