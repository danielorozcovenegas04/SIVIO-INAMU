using SIVIO.Entidades;
using SIVIO.InamuComun;
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

       
        public ActionResult DetalleUsuaria()
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
        public ActionResult CrearUsuaria_DatosPerfil()
        {
            /*
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View((int)System.Web.HttpContext.Current.Session["tipoServicio"]);
            }
            else if (!estadoSesion)
            {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            }
            else
            {
                return View(viewName: "~/Views/Shared/Errores/Error.cshtml");
            }
            */
            return View(viewName: "~/Views/Expediente/CrearUsuaria_DatosPerfil.cshtml");
        }

        [Authorize]
        public ActionResult MenuExpediente()
        {
            /*
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View((int)System.Web.HttpContext.Current.Session["tipoServicio"]);
            }
            else if (!estadoSesion)
            {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            }
            else
            {
                return View(viewName: "~/Views/Shared/Errores/Error.cshtml");
            }
            */
            return View(viewName: "~/Views/Expediente/MenuExpediente.cshtml");
        }

        public ActionResult CrearUsuaria_DatosAdministrativos()
        {
            /*
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View((int)System.Web.HttpContext.Current.Session["tipoServicio"]);
            }
            else if (!estadoSesion)
            {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            }
            else
            {
                return View(viewName: "~/Views/Shared/Errores/Error.cshtml");
            }
            */
            return View(_modelExpediente); 
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
        public List<SP_LISTAR_CATEGORIAS_VIOLENCIA_CUESTIONARIO_Result> ListarCategoriasViolenciaCuestionario()
        {
            return _modelExpediente.ListarCategoriasViolenciaCuestionario();
        }

        [ChildActionOnly]
        public PartialViewResult CuestionarioCriterioViolenciaDelegacion()
        {
            return PartialView(_modelExpediente.ListarCategoriasViolenciaCuestionario());
        }



        public PartialViewResult DatAdministrativosDele()
        {
            return PartialView(viewName: "~/Views/Expediente/DatAdministrativosDele.cshtml");
        }

        public PartialViewResult DatUsuariaDele()
        {
            return PartialView(viewName: "~/Views/Expediente/DatUsuariaDele.cshtml");
        }

        public PartialViewResult DatPerfil()
        {
            return PartialView(viewName: "~/Views/Expediente/DatPerfil.cshtml");
        }

        public PartialViewResult HistorialViolenciaDele()
        {
            return PartialView(viewName: "~/Views/Expediente/HistorialViolenciaDele.cshtml");
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

        [Authorize]
        public ActionResult ConsultaCoavif()
        {
            var listaPersonas = _modelExpediente.ListarPersonas();
            var listaUsuarios = _modelExpediente.ListarPersonas();
            return View(_modelExpediente.ListarPersonas());
        }
        #endregion

        #region Delegacion

        [HttpPost]
        public Mensaje CrearUsuaria_DatosUsuaria(TBL_PERSONA objDatosUsuaria)
        {

                //  var name = datosForm["name"];
                //   var lastName1 = datosForm["lastName1"];
                //  var lastName2 = datosForm["lastName2"];
                //  var mail = datosForm["mail"];

               // TBL_PERSONA user = new TBL_PERSONA();
                //user.VC_NOMBRE = datosForm["Nombre"];
                //user.VC_APELLIDO1 = datosForm["Apellido1"];
                //user.VC_APELLIDO2 = datosForm["Apellido2"];
                //user.VC_IDENTIFICACION = datosForm["Identificacion"];
                //user.DT_FECHANACIMIENTO = DateTime.Parse(datosForm["FechaNacimiento"]);
                // ¿EDAD?
                //   user.FK_PROVINCIAPROCEDENCIA = datosForm["ProvinciaPersona"]; // Es un int, se requiere el valor.
                /*
                var context = new INAMU_COMUNEntities();
                var pk_provincia = from I_IDPROVINCIA in context.CAT_PROVINCIA
                                 where I_IDPROVINCIA.CAT_CANTON.Any(r => r.VC_DESCRIPCION == datosForm["ProvinciaPersona"])
                                   select I_IDPROVINCIA;

                Console.WriteLine(pk_provincia);
                //usuario.TBL_ROL_USUARIO.Select(m => m.TBL_ROL.VC_NOMBRE)

                //        user.FK_CANTONPROCEDENCIA = pk_provincia;


                //      user.IM_CLAVE = StrToByteArray("mae");
                //      user.IM_SALT1 = StrToByteArray("mae");
                //      user.IM_SALT2 = StrToByteArray("mae");
                */
                return _modelExpediente.InsertarUsuaria(objDatosUsuaria);
            

        }


        [Authorize]
        public JsonResult ListarProfesionales()
        {
            return Json(_modelExpediente.ListarProfesionales(), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Delegacion_Mujer()
        {
     
            return View();
        }

        public JsonResult CargarDropdowns()
        {
            dynamic objetoRetorno = new ExpandoObject();
            try
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
                objetoRetorno.CatalogoNacionalidad = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Nacionalidad).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoCondicionCivil = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.EstadoCivil).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoEscolaridad = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.GradoAcademico).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoEmbarazo = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Embarazo).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoCondicionMigratoria = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.SituacionMigratoria).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoOcupacion = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Ocupacion).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoIdentidadGenero = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Genero).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoOrigenEtnico = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Etnia).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoCondicionLaboral = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.SituacionLaboral).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoTipoFamilia = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoFamilia).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoTipoVivienda = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoVivienda).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoParentesco = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Parentesco).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoTipoAtencion = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoAtencion).
                   TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoViolencia = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.SituacionEnfrentada).
                     TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoOrientacionSexual = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.OrientacionSexual).
                  TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.CatalogoCondicionAseguramiento = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.CondicionAseguramiento).
                  TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.Padecimientos = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Padecimiento).
                     TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.Adicciones = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Adiccion).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.TipoRedApoyo = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoRedApoyo).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                objetoRetorno.Institucion = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.Institucion).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                //objetoRetorno.profecional = ;
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception e)
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error al cargar catálogos", string.Empty);
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
        }


        #endregion
    }
}