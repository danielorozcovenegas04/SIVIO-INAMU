using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIVIO.UI.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
            {
                return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ComprobarPermisosAcccion(string usuario)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var manejoSeguridad = new Models.SeguridadModel();
            return manejoSeguridad.ValidarPermisoAccion(usuario, controllerName, actionName);
        }
    }
}