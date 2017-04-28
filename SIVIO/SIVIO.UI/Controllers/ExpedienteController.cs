using SIVIO.Entidades;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using COMUN_MODELO;
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
        
        [AllowAnonymous]
        public JsonResult ListarCatalogosCrearCaso()
        {
            List<int> catalogos = new List<int>()
            {
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoCEAAM,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoIngresoCEEAM,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoEgresoCEEAM,
                (int)Utilitarios.Enumerados.EnumCatalogos.RespuestaSiNosponible,

            };
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_modelCatalogos.llenarListaCatalogos(catalogos)), JsonRequestBehavior.AllowGet);
        }




        [Authorize]
        public ActionResult CrearUsuariaAtencionComunidad() {
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
            //TBL_REGISTRO
            var listaPersonas = _modelExpediente.ListarPersonas();
            var listaUsuarios = _modelExpediente.ListarUSuarios();
            var listaConsulta = _modelExpediente.ListarConsultas();
            var listaRegistro = _modelExpediente.ListarRegistro();
            var listaCatalogo = _modelExpediente.ListarCatalogo();
            var listaAtencion = _modelExpediente.ListarAtencion();
            
            foreach (var r in listaRegistro)
            {
                foreach (var u in listaUsuarios)
                {
                    if (r.FK_USUARIOREGISTRA == u.PK_USUARIO)
                    {
                        r.TBL_USUARIO = new TBL_USUARIO();
                        r.TBL_USUARIO.PK_USUARIO = u.PK_USUARIO;
                        r.TBL_USUARIO.VC_APELLIDO1 = u.VC_APELLIDO1;
                        r.TBL_USUARIO.VC_APELLIDO2 = u.VC_APELLIDO2;
                        r.TBL_USUARIO.VC_NOMBRE = u.VC_NOMBRE;
                        
                    }
                }
                foreach (var p in listaPersonas)
                {
                    if (r.FK_PERSONA == p.PK_PERSONA)
                    {
                        r.TBL_PERSONA = new TBL_PERSONA();
                        r.TBL_PERSONA.PK_PERSONA = p.PK_PERSONA;
                        r.TBL_PERSONA.VC_NOMBRE = p.VC_NOMBRE;
                        r.TBL_PERSONA.VC_APELLIDO1 = p.VC_APELLIDO1;
                        r.TBL_PERSONA.VC_APELLIDO2 = p.VC_APELLIDO2;
                        r.TBL_PERSONA.VC_IDENTIFICACION = p.VC_IDENTIFICACION;
                    }

                }
                foreach (var c in listaCatalogo)
                {
                    if (r.FK_TIPOSERVICIO == c.FK_CATALOGO) {
                        r.TBL_VALOR_CATALOGO = new TBL_VALOR_CATALOGO();
                        r.TBL_VALOR_CATALOGO.FK_CATALOGO = c.FK_CATALOGO;
                        r.TBL_VALOR_CATALOGO.VC_VALOR1 = c.VC_VALOR1;
                    }
                    {
                        
                    }

                }
                
            }
            return View(listaRegistro);
        }

        [Authorize]
        public ActionResult ConsultaPersona()
        {

            return View();
        }
        #endregion
    }
}