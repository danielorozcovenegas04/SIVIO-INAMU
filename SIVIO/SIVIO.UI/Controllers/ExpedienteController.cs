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
        
        [AllowAnonymous]
        public JsonResult ListarCatalogosCrearCaso()
        {
            List<int> catalogos = new List<int>()
            {
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoCEAAM,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoIngresoCEAAM,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoEgresoCEAAM,
                (int)Utilitarios.Enumerados.EnumCatalogos.OrientacionSexual,
                (int)Utilitarios.Enumerados.EnumCatalogos.Etnia,
                (int)Utilitarios.Enumerados.EnumCatalogos.EstadoCivil,
                (int)Utilitarios.Enumerados.EnumCatalogos.GradoAcademico,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoFamilia,
                (int)Utilitarios.Enumerados.EnumCatalogos.Nacionalidad,
                (int)Utilitarios.Enumerados.EnumCatalogos.SituacionMigratoria,
                (int)Utilitarios.Enumerados.EnumCatalogos.SituacionLaboral,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoVivienda,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoDiscapacidad,
                (int)Utilitarios.Enumerados.EnumCatalogos.Adiccion,
                (int)Utilitarios.Enumerados.EnumCatalogos.Genero,
                (int)Utilitarios.Enumerados.EnumCatalogos.NumeroSeparacionesAgresor,
                (int)Utilitarios.Enumerados.EnumCatalogos.MotivoReanudarRelacionAgresor,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoAtencionMedica,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoViolencia,
                (int)Utilitarios.Enumerados.EnumCatalogos.ImpactoProductoViolencia,
                (int)Utilitarios.Enumerados.EnumCatalogos.ValoracionRiesgo,
                (int)Utilitarios.Enumerados.EnumCatalogos.CondicionLegalIngreso,
                (int)Utilitarios.Enumerados.EnumCatalogos.MedidaProteccion,
                (int)Utilitarios.Enumerados.EnumCatalogos.SituacionViolenciaFisica,
                (int)Utilitarios.Enumerados.EnumCatalogos.SituacionViolenciaPsicologica,
                (int)Utilitarios.Enumerados.EnumCatalogos.SituacionViolenciaSexual,
                (int)Utilitarios.Enumerados.EnumCatalogos.SituacionViolenciaPatrimonial,
                (int)Utilitarios.Enumerados.EnumCatalogos.RespuestaSiNosponible,

            };
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_modelCatalogos.llenarListaCatalogos(catalogos)), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult CrearUsuariaAtencionComunidadPost(TBL_PERSONA persona, TBL_AGRESOR agresor) {
            try {
                var listaAgresor = new List<TBL_AGRESOR>();
                listaAgresor.Add(agresor);
                persona.TBL_AGRESOR = listaAgresor;
                _modelExpediente.InsertarPersonaConAgresor(persona, agresor);
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(new { success = "true" }));
            } catch (Exception ex) {
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(new { success = "false", error = ex.ToString() }));
            }

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
        public ActionResult GridConsultas(Guid caso)
        {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View(_modelExpediente.ListarConsultas(caso));
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

        [Authorize]
        public ActionResult ConsultaCoavif()
        {
           
            var listaPersonas = _modelExpediente.ListarPersonas();
            var listaUsuarios = _modelExpediente.ListarUSuarios();
            var listaRol = _modelExpediente.ListarRoles();
            var listaConsulta = _modelExpediente.ListarConsultas();
            var listaRolUsuario = _modelExpediente.ListarUSuariosRoles();
            foreach (var rol in listaRol) {
                foreach (var usuario in listaUsuarios) {
                    foreach (var rolusuario in listaRolUsuario)
                    {
                        if (rol.PK_ROL==rolusuario.FK_ROL && usuario.PK_USUARIO==rolusuario.FK_USUARIO) {
                            ViewBag.grid(rol.VC_NOMBRE,(usuario.VC_NOMBRE+ usuario.VC_APELLIDO1));
                        }
                    }
                }
            }
            
            return View(_modelExpediente.ListarPersonas());
        }


        #endregion
    }
}