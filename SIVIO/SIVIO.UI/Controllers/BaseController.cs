using SIVIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        public bool ComprobarPermisosAcccion()
        {
            try
            {
                var usuarioActual = (TBL_USUARIO)System.Web.HttpContext.Current.Session["usuarioActual"];
                if (usuarioActual == null)
                {
                    FormsAuthentication.SignOut();
                    return false;
                }
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var manejoSeguridad = new Models.SeguridadModel();
                return manejoSeguridad.ValidarPermisoAccion(controllerName, actionName,usuarioActual);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}