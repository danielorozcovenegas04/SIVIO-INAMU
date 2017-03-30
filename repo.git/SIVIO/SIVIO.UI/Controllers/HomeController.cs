using SIVIO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SIVIO.UI.Controllers
{
    public class HomeController : Controller
    {
        #region Modelos

        SIVIO.UI.Models.SeguridadModel _modelSeguridad = new Models.SeguridadModel();

        #endregion

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Ingreso()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult AutenticarUsuario(string usuario, string clave)
        {
            var directorioAd = System.Configuration.ConfigurationManager.AppSettings.Get("rutaAD");
            var usuarioConsulta = new TBL_USUARIO { VC_USUARIO = usuario };
            usuarioConsulta = _modelSeguridad.BuscarUsuario(usuarioConsulta);
            if (usuarioConsulta == null)
            {
                return Json(new Mensaje((int)Mensaje.CatTipoMensaje.Error, "El usuario digitado no existe", "valor"), JsonRequestBehavior.AllowGet);
            }
            if (!Utilitarios.Util.AutenticadoAd(directorioAd, usuario, clave))
            {
                if (!_modelSeguridad.ValidarClave(clave, usuarioConsulta))
                {
                    return Json(new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error al comprobar credenciales", "valor"), JsonRequestBehavior.AllowGet);
                }
            }
            FormsAuthentication.SetAuthCookie(usuarioConsulta.VC_USUARIO, false);
            HttpContext.Application["usuarioActual"] = usuarioConsulta;
            return Json(
                new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, 
                usuarioConsulta.PK_USUARIO.ToString(), 
                string.Empty),JsonRequestBehavior.AllowGet);

        }


    }
}