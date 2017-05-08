using SIVIO.Entidades;
using SIVIO.InamuComun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult CrearCaso(string ValorPersona)
        {
           // bool estadoSesion = true;
            /* if (ComprobarPermisosAcccion(out estadoSesion))
            {
                if (String.IsNullOrEmpty(pk_persona))
                {
                    return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
                }

                var persona = _modelExpediente.ListarRegistros(Int32.Parse(pk_persona));

                return View();

            }*/

            if (String.IsNullOrEmpty(ValorPersona))
            {
                return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
            }

             TBL_PERSONA persona = _modelExpediente.ObtenerPersona(ValorPersona);
            
            return View(persona);

            
           /* else if (!estadoSesion)
            {
                return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            }
            else
            {
                return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
            }*/
            
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
                (int)Utilitarios.Enumerados.EnumCatalogos.Ocupacion,
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

       
        public ActionResult DetalleUsuaria()
        {
            return View();
        }

        [Authorize]
        public ActionResult CrearUsuariaAtencionComunidadPost(
            TBL_PERSONA persona,            TBL_AGRESOR agresor,
            TBL_LABORAL laboral,            TBL_ADICCIONES adicciones,
            TBL_PERSONA_RED_APOYO apoyo1,   TBL_AGRESION agresion,
            TBL_AGRESOR_MOTIVO_REGRESO agresorMotivoRegreso,    TBL_AGRESION_ATENCION_MEDICA agresionAtencionMedica,
            TBL_AGRESION_VIOLENCIA agresionViolencia,           TBL_AGRESOR_ADICCIONES agresorAdicciones,
            TBL_AGRESION_IMPACTO_VIOLENCIA impactoViolencia,    TBL_PERSONA_CONDICIONESPECIAL dispacidades) {
            try {
                var listaAgresor = new List<TBL_AGRESOR>();
                listaAgresor.Add(agresor);
                persona.TBL_AGRESOR = listaAgresor;

                adicciones.PK_ADICCION = Guid.NewGuid();
                var listaAdicciones = new List<TBL_ADICCIONES>();
                listaAdicciones.Add(adicciones);
                persona.TBL_ADICCIONES = listaAdicciones;
                /*
                var listaApoyo1 = new List<TBL_PERSONA_RED_APOYO>();
                listaApoyo1.Add(apoyo1);
                persona.TBL_PERSONA_RED_APOYO = listaApoyo1;
                */

                agresion.PK_AGRESION = Guid.NewGuid();
                var listaAgresion = new List<TBL_AGRESION>();
                listaAgresion.Add(agresion);
                agresor.TBL_AGRESION = listaAgresion;

                agresorMotivoRegreso.PK_MOTIVOREGRESO = Guid.NewGuid();
                var listaAgresorMotivoRegreso = new List<TBL_AGRESOR_MOTIVO_REGRESO>();
                listaAgresorMotivoRegreso.Add(agresorMotivoRegreso);
                agresor.TBL_AGRESOR_MOTIVO_REGRESO = listaAgresorMotivoRegreso;

                agresionAtencionMedica.PK_ATENCION_MEDICA = Guid.NewGuid();
                var listaAgresionAtencionMedica = new List<TBL_AGRESION_ATENCION_MEDICA>();
                listaAgresionAtencionMedica.Add(agresionAtencionMedica);
                agresion.TBL_AGRESION_ATENCION_MEDICA = listaAgresionAtencionMedica;

                agresionViolencia.PK_AGRESION_VIOLENCIA = Guid.NewGuid();
                var listaAgresionViolencia = new List<TBL_AGRESION_VIOLENCIA>();
                listaAgresionViolencia.Add(agresionViolencia);
                agresion.TBL_AGRESION_VIOLENCIA = listaAgresionViolencia;

                agresorAdicciones.PK_AGRESORADICION = Guid.NewGuid();
                var listaAgresorAdicciones = new List<TBL_AGRESOR_ADICCIONES>();
                listaAgresorAdicciones.Add(agresorAdicciones);
                agresor.TBL_AGRESOR_ADICCIONES = listaAgresorAdicciones;

                impactoViolencia.PK_IMPACTOVIOLENCIA = Guid.NewGuid();
                var listaImpactoViolencia = new List<TBL_AGRESION_IMPACTO_VIOLENCIA>();
                listaImpactoViolencia.Add(impactoViolencia);
                agresion.TBL_AGRESION_IMPACTO_VIOLENCIA = listaImpactoViolencia;

                dispacidades.PK_CONDICIONESPECIAL = Guid.NewGuid();
                var listaDispacidades = new List<TBL_PERSONA_CONDICIONESPECIAL>();
                listaDispacidades.Add(dispacidades);
                persona.TBL_PERSONA_CONDICIONESPECIAL = listaDispacidades;

                persona.TBL_LABORAL = laboral;

                _modelExpediente.InsertarPersonaConAgresor(persona, agresor, laboral, adicciones,
                    apoyo1, agresion, agresorMotivoRegreso, agresionAtencionMedica, agresionViolencia,
                    agresorAdicciones, impactoViolencia, dispacidades);
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
            _modelExpediente.fecha = DateTime.Now.Date;
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
        public ActionResult BusquedaExpedienteCEAAM(string palabra)
        {
            //bool estadoSesion = true;
            //if (ComprobarPermisosAcccion(out estadoSesion))
            //{
                return View(_modelExpediente.BuscarExpedienteCEAAM(palabra));

            //}
            //else if (!estadoSesion)
            //{
            //    return View(viewName: "~/Views/Shared/Errores/Sesion.cshtml");
            //}
            //else
            //{
            //    return View(viewName: "~/Views/Shared/Errores/ErrorParcial.cshtml");
            //}
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
        public ActionResult Coavif(int pkUsuario)
        {
            return View(_modelExpediente.BuscarPersona(pkUsuario));
        }

        //[Authorize]
        //public ActionResult Coavif()
        //{
        //    return View(new TBL_PERSONA());
        //}

        [Authorize]
        public ActionResult BusquedaExpedienteCoavif(string palabra)
        {
            return View(_modelExpediente.ListarPersonas(palabra));            
        }

        [AllowAnonymous]
       public JsonResult CargarPersonas() {
            dynamic objeto = new ExpandoObject();
            using (var entidades = new SIVIOEntities()) {
                try
                {
                    objeto.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
                    var user = HttpContext.User.Identity.Name;
                    var usuario = entidades.TBL_USUARIO.Where(m => m.VC_USUARIO == user).First();
                    objeto.usuarioNombre = usuario.VC_NOMBRE;
                    objeto.usuarioApellido1 = usuario.VC_APELLIDO1;
                    objeto.usuarioApellido2 = usuario.VC_APELLIDO2;
                    objeto.usuarioRol = usuario.TBL_ROL_USUARIO.First().FK_ROL;
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
                objetoRetorno.CatalogoIntitucion = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.PersonaInstucionRefiere).
                    TBL_VALOR_CATALOGO.Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Error,"Error al cargar catalogos", string.Empty);
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(objetoRetorno), JsonRequestBehavior.AllowGet);
            }
        }

        [AllowAnonymous]
        public Mensaje guardarDatoAdministrativo(FormCollection objUsuarios)
        {//parametro que recibe de la vista            
            using (var entidades = new SIVIOEntities())
            {
                var fecha = objUsuarios["Fecha"];
                var hora = objUsuarios["HoraInicio"];
                var pers = objUsuarios["Persona"];
                var disp = objUsuarios["TipoDisponibilidad"];

                var user = HttpContext.User.Identity.Name;
                TBL_USUARIO usuario = entidades.TBL_USUARIO.Where(m => m.VC_USUARIO == user).First();

                DateTime fechaInicio = DateTime.ParseExact(fecha + hora, "dd/MM/yyyyHH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.Now;

                int idPersona;
                int disponibilidad = 0;
                bool bol = Int32.TryParse(pers, out idPersona);
                bol = Int32.TryParse(disp, out disponibilidad);
                TBL_REGISTRO registro = new TBL_REGISTRO();
                registro.PK_REGISTRO = Guid.NewGuid();
                registro.FK_PERSONA = idPersona;
                registro.FK_USUARIOREGISTRA = usuario.PK_USUARIO;
                registro.DT_FECHAINICIO = fechaInicio;
                registro.DT_FECHAFIN = fechaFin;
                registro.FK_TIPOSERVICIO = usuario.TBL_ROL_USUARIO.First().TBL_ROL.PK_ROL;
                registro.FK_TIPOREGISTRO = 549;
                return _modelExpediente.InsertarDatosAdministrativos(registro);
            }

        }

        [AllowAnonymous]
        public Mensaje CrearNuevoCaso(int id)
        {
            using (var entidades = new SIVIOEntities())
            {
                TBL_ATENCION caso = new TBL_ATENCION();
                caso.PK_ATENCION = Guid.NewGuid();
                caso.DT_FECHAINICIO = DateTime.Now;
                caso.DT_FECHAFIN = new DateTime().AddYears(1980);
                caso.FK_TIPOATENCION = 573;
                var lista = entidades.TBL_REGISTRO.ToList();
                DateTime date = new DateTime();
                TBL_REGISTRO registro = new TBL_REGISTRO();
                foreach (var r in lista)
                {
                    if (r.FK_PERSONA == id && r.DT_FECHAINICIO > date)
                    {
                        date = r.DT_FECHAINICIO;
                        registro = r;
                    }
                }
                caso.FK_REGISTRO = registro.PK_REGISTRO;
                entidades.TBL_ATENCION.Add(caso);
                entidades.SaveChanges();
            }
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
        }
        [AllowAnonymous]
        public Mensaje CerrarCaso(int id)
        {
            using (var entidades = new SIVIOEntities())
            {
                var listaRegistros = entidades.TBL_REGISTRO.ToList();
                DateTime date = new DateTime();
                TBL_REGISTRO registro = new TBL_REGISTRO();
                foreach (var r in listaRegistros)
                {
                    if (r.FK_PERSONA == id && r.DT_FECHAINICIO > date)
                    {
                        date = r.DT_FECHAINICIO;
                        registro = r;
                    }
                }
                var listaCasos = entidades.TBL_ATENCION.ToList();
                TBL_ATENCION caso = new TBL_ATENCION();
                foreach (var c in listaCasos)
                {
                    if (c.FK_REGISTRO == registro.PK_REGISTRO && c.DT_FECHAFIN == new DateTime().AddYears(1980))
                    {
                        caso = entidades.TBL_ATENCION.Find(c.PK_ATENCION);
                    }
                }
                caso.DT_FECHAFIN = DateTime.Now;
                entidades.SaveChanges();
            }
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
        }

        [Authorize]
        public ActionResult ConsultaCoavif()
        {
            int t = 0;
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
//if (r.TBL_VALOR_CATALOGO==null) {
                        
                       
                  //  }
                    if (r.FK_TIPOSERVICIO == c.FK_CATALOGO) {
                        r.TBL_VALOR_CATALOGO = new TBL_VALOR_CATALOGO();
                        r.TBL_VALOR_CATALOGO1 = new TBL_VALOR_CATALOGO();
                        r.TBL_VALOR_CATALOGO.FK_CATALOGO = c.FK_CATALOGO;
                        r.TBL_VALOR_CATALOGO.VC_VALOR1 = c.VC_VALOR1;
                        r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "0";

                    }
                    if (r.FK_TIPOREGISTRO == c.FK_CATALOGO)
                    {
                       
                        r.TBL_VALOR_CATALOGO1.FK_CATALOGO = c.FK_CATALOGO;
                        r.TBL_VALOR_CATALOGO1.VC_VALOR1 = c.VC_VALOR1;
                        
                    }
                }
                foreach (var c in listaConsulta)
                {
                   if (r.PK_REGISTRO==c.FK_REGISTRO ) {
                        r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "1";
                    }
                }
                foreach (var a in listaAtencion)
                {
                    if (r.PK_REGISTRO == a.FK_REGISTRO )
                    {
                        r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "2";
                    }
                }
                //SOLO PARA PRUEBAS ELIMINAR
              /* if (t == 0)
                {
                    r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "1";
                }
                if ( t == 1)
                {
                    r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "2";
                }
                t++;*/
                //SOLO PARA PRUEBAS ELIMINAR
            }
            return View(listaRegistro);
        }

        [Authorize]
        public ActionResult ConsultaPersona(string persona)
        {
            int t = 0;
           // string persona = "Juliana Trump Beckenbauer";
            var listaPersonas = _modelExpediente.ListarPersonas();
            var listaUsuarios = _modelExpediente.ListarUSuarios();
            var listaConsulta = _modelExpediente.ListarConsultas();
            var listaRegistro = _modelExpediente.ListarRegistro();
            var listaCatalogo = _modelExpediente.ListarCatalogo();
            var listaAtencion = _modelExpediente.ListarAtencion();
            var infopersona = new List<TBL_REGISTRO>();
            foreach (var p in listaPersonas) {
                var nombre = p.VC_NOMBRE + " " + p.VC_APELLIDO1 + " " + p.VC_APELLIDO2;
                if (persona.CompareTo(nombre) == 0) {
                    foreach (var r in listaRegistro) {
                        if (r.TBL_PERSONA == null) {
                            r.TBL_PERSONA = new TBL_PERSONA();
                            r.TBL_PERSONA.VC_NOMBRE = p.VC_NOMBRE;
                            r.TBL_PERSONA.VC_APELLIDO1 = p.VC_APELLIDO1;
                            r.TBL_PERSONA.VC_APELLIDO2 = p.VC_APELLIDO2;
                            ViewBag.NombrePersona= p.VC_NOMBRE + " " + p.VC_APELLIDO1 + " " + p.VC_APELLIDO2;
                            ViewBag.IdPersona = p.VC_IDENTIFICACION;
                            ViewBag.Expediente = p.PK_PERSONA;
                        }
                        if (r.FK_PERSONA == p.PK_PERSONA) {
                            infopersona.Add(r);
                        }
                    }
                }
            }
            foreach (var ip in infopersona) {
                foreach (var u in listaUsuarios)
                {
                    if (ip.FK_USUARIOREGISTRA == u.PK_USUARIO)
                    {
                        ip.TBL_USUARIO = new TBL_USUARIO();
                        ip.TBL_USUARIO.PK_USUARIO = u.PK_USUARIO;
                        ip.TBL_USUARIO.VC_APELLIDO1 = u.VC_APELLIDO1;
                        ip.TBL_USUARIO.VC_APELLIDO2 = u.VC_APELLIDO2;
                        ip.TBL_USUARIO.VC_NOMBRE = u.VC_NOMBRE;
                        ip.TBL_USUARIO.VC_USUARIO = u.VC_USUARIO;
                    }
                }
                foreach (var c in listaCatalogo)
                {
                    if (ip.TBL_VALOR_CATALOGO == null)
                    {
                        ip.TBL_VALOR_CATALOGO = new TBL_VALOR_CATALOGO();
                        ip.TBL_VALOR_CATALOGO1 = new TBL_VALOR_CATALOGO();
                    }
                    if (ip.FK_TIPOSERVICIO == c.FK_CATALOGO)
                    {
                        ip.TBL_VALOR_CATALOGO.FK_CATALOGO = c.FK_CATALOGO;
                        ip.TBL_VALOR_CATALOGO.VC_VALOR1 = c.VC_VALOR1;

                    }
                    if (ip.FK_TIPOREGISTRO == c.FK_CATALOGO)
                    {
                        ip.TBL_VALOR_CATALOGO1.FK_CATALOGO = c.FK_CATALOGO;
                        ip.TBL_VALOR_CATALOGO1.VC_VALOR1 = c.VC_VALOR1;

                    }
                }
                foreach (var c in listaConsulta)
                {
                    if (ip.PK_REGISTRO == c.FK_REGISTRO)
                    {
                        ip.TBL_VALOR_CATALOGO1.VC_VALOR2 = "1";
                    }
                }
                foreach (var a in listaAtencion)
                {
                    if (ip.PK_REGISTRO == a.FK_REGISTRO)
                    {
                        ip.TBL_VALOR_CATALOGO1.VC_VALOR2 = "2";
                    }
                }
                //SOLO PARA PRUEBAS ELIMINAR
                /*if (t == 0)
                {
                    ip.TBL_VALOR_CATALOGO1.VC_VALOR2 = "1";
                }
                if (t == 1)
                {
                    ip.TBL_VALOR_CATALOGO1.VC_VALOR2 = "2";
                }
                t++;*/
            }
            return View(infopersona);
        }
        #endregion

        #region Delegacion

        [HttpPost]
        public Mensaje CrearUsuaria_DatosUsuaria(TBL_PERSONA objDatosUsuaria)
        {
            using (var entities = new SIVIOEntities())
            {
                //  var name = datosForm["name"];
                //   var lastName1 = datosForm["lastName1"];
                //  var lastName2 = datosForm["lastName2"];
                //  var mail = datosForm["mail"];

                //TBL_PERSONA user = new TBL_PERSONA();
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

                //  return _modelExpediente.InsertarUsuaria(user);*/
                return null;
            }

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
                objetoRetorno.CatalogoTipoAtencion = _modelCatalogos.ObtenerCatalogoPorId((int)Utilitarios.Enumerados.EnumCatalogos.TipoAtencionViolencia).
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