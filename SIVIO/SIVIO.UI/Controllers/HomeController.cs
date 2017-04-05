using SIVIO.Entidades;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace SIVIO.UI.Controllers
{
    public class HomeController : Controller
    {
        #region Modelos

        SIVIO.UI.Models.SeguridadModel _modelSeguridad = new Models.SeguridadModel();
        SIVIO.UI.Models.CatalogosModel _modelCatalogos = new Models.CatalogosModel();

        #endregion

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Ingreso()
        {
            //var usuario = new TBL_USUARIO();
            //usuario.VC_NOMBRE = "ANA";
            //usuario.VC_APELLIDO1 = "COTO";
            //usuario.VC_APELLIDO2 = "COTO";
            //usuario.VC_CORREO = "adminsivio@inamu.go.cr";
            //usuario.VC_USUARIO = "adminsivio@inamu.go.cr";

            //var salt1 = Guid.NewGuid().ToByteArray();
            //var salt2 = Guid.NewGuid().ToByteArray();
            //var clave = SIVIO.Utilitarios.Util.GenerarClave(usuario.VC_USUARIO, "rosebud", 2, salt1, salt2);
            //usuario.IM_CLAVE = clave;
            //usuario.IM_SALT1 = salt1;
            //usuario.IM_SALT2 = salt2;
            //_modelSeguridad.InsertarUsuario(usuario);
            return View();
        }

        [AllowAnonymous]
        public JsonResult AutenticarUsuario(string usuario, string clave, int tipoServicio)
        {
            try
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
                Session["usuarioActual"] = usuarioConsulta;
                Session["tipoServicio"] = tipoServicio;
                return Json(
                    new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso,
                    usuarioConsulta.PK_USUARIO.ToString(),
                    string.Empty), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error de sistema, contacte a la persona administradora", "valor"), JsonRequestBehavior.AllowGet);
            }

        }
        [AllowAnonymous]
        public JsonResult ListarTiposServicio()
        {
            dynamic objetoRetorno = new ExpandoObject();
            try
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
                objetoRetorno.Catalogo = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoServicio).
                    TBL_VALOR_CATALOGO.Select(m=> new { m.PK_VALORCATALOGO,m.VC_VALOR1,m.VC_VALOR2});
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Error,"Error al cargar tipos de servicio", string.Empty);
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
        }


    }
}