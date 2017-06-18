using DauGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Fitters
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public int RequiredPermission { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentContext.IsLogged() == false)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                filterContext.Result = new RedirectResult(string.Format(
                    "~/Account/Login?retUrl=/{0}/{1}",
                    controller,
                    action
                    )
                    );
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}