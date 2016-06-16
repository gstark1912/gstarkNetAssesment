using MVC.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!string.IsNullOrEmpty(SimpleSessionPersister.Username))
            {
                filterContext.HttpContext.User = new CustomPrincipal(new CustomIdentity(SimpleSessionPersister.Username));
            }
            base.OnAuthorization(filterContext);
        }
    }
}
