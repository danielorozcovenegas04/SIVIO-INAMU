using SIVIO.Entidades;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SIVIO.UI.Models.ExpedienteModel;

namespace SIVIO.UI.Controllers
{
    public class ExpedienteController : BaseController
    {
        #region Modelos
        SIVIO.UI.Models.ExpedienteModel _modelExpediente = new Models.ExpedienteModel();
        SIVIO.UI.Models.CatalogosModel _modelCatalogos = new Models.CatalogosModel();
        #endregion

        // GET: Expediente
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult CrearCaso()
        {
            return View();
        }

        [Authorize]
        public ActionResult FrmCrearUsuariaAT() {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion)) {
                return View((int)System.Web.HttpContext.Current.Session["tipoServicio"]);
            } else if (!estadoSesion) {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            } else {
                return View(viewName: "~/Views/Shared/Errores/Error.cshtml");
            }
        }

        [Authorize]
        public ActionResult BusquedaExpediente(string palabra) {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion)) {
                return View(_modelExpediente.ListarPersonas(palabra));

            } else if (!estadoSesion) {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            } else {
                return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
            }
        }

        [Authorize]
        public ActionResult GridConsultas(int persona)
        {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View(_modelExpediente.ListarConsultas(persona));
            }
            else if (!estadoSesion)
            {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            }
            else
            {
                return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
            }
        }

        [Authorize]
        public ActionResult GridRegistros(int persona)
        {
            return View(_modelExpediente.ListarRegistros(persona));
            bool estadoSesion = true;
            if(ComprobarPermisosAcccion(out estadoSesion))
            {
                return View(_modelExpediente.ListarRegistros(persona));
            }
            else if (!estadoSesion)
            {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            }
            else
            {
                return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
            }
        }

        #region Coavif
        [Authorize]
        public ActionResult Coavif()
        {
            //var catalogoServicios = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Nacionalidad);
            return View();
        }
        [AllowAnonymous]
        public JsonResult CargarPersonas() {
            dynamic objeto = new ExpandoObject();
            using (var entidades = new SIVIOEntities()) {
                try
                {
                    objeto.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
                    var persona = entidades.TBL_PERSONA.Where(m => m.PK_PERSONA == 1).First();
                    objeto.personaNombre = persona.VC_NOMBRE;
                    objeto.personaApellido1 = persona.VC_APELLIDO1;
                    objeto.personaApellido2 = persona.VC_APELLIDO2;
                    objeto.personaCorreo = persona.VC_CORREO;
                    if (persona.TBL_TELEFONO.Count > 0)
                    {
                        objeto.personaTelefono = persona.TBL_TELEFONO.First().VC_NUMERO;
                    }
                    else {
                        objeto.personaTelefono = "";
                    }                    
                    var user = HttpContext.User.Identity.Name;
                    var usuario = entidades.TBL_USUARIO.Where(m => m.VC_USUARIO == user).First();
                    objeto.usuarioNombre = usuario.VC_NOMBRE;
                    objeto.usuarioApellido1 = usuario.VC_APELLIDO1;
                    objeto.usuarioApellido2 = usuario.VC_APELLIDO2;
                    return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objeto), JsonRequestBehavior.AllowGet);

                }
                catch (Exception e) {
                    objeto.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error al cargar persona", string.Empty);
                    return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objeto), JsonRequestBehavior.AllowGet);
                }
            }                
        }

        [AllowAnonymous]
        public JsonResult CargarCatalogos()
        {
            dynamic objetoRetorno = new ExpandoObject();
            try
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
                objetoRetorno.CatalogoTiposDisponibilidad = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoDisponibilidad).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoNacionalidad = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Nacionalidad).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoCondicionMigratoria = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.SituacionMigratoria).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoDiscapasidades = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoDiscapacidad).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Error,"Error al cargar catalogos", string.Empty);
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        public ActionResult ConsultaCoavif()
        {

            var listaPersonas = _modelExpediente.ListarPersonas();
            var listaUsuarios = _modelExpediente.ListarUSuarios();
            var listaRol = _modelExpediente.ListarRoles();
            var listaConsulta = _modelExpediente.ListarConsultas();
            var listaRolUsuario = _modelExpediente.ListarUSuariosRoles();
            foreach (var rol in listaRol)
            {
                foreach (var usuario in listaUsuarios)
                {
                    foreach (var rolusuario in listaRolUsuario)
                    {
                        if (rol.PK_ROL == rolusuario.FK_ROL && usuario.PK_USUARIO == rolusuario.FK_USUARIO)
                        {
                            ViewBag.grid(rol.VC_NOMBRE, (usuario.VC_NOMBRE + usuario.VC_APELLIDO1));
                        }
                    }
                }
            }

            return View(_modelExpediente.ListarPersonas());
        }
        #endregion
    }
}