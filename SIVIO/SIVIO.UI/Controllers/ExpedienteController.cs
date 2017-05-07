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
        public ActionResult CrearUsuaria_DatosUsuaria()
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
            return View(viewName: "~/Views/Expediente/CrearUsuaria_DatosUsuaria.cshtml");
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

                DateTime fechaInicio = DateTime.Parse(fecha + " " + hora);
                //DateTime fechaInicio = DateTime.ParseExact(fecha + hora, "dd/MM/yyyyHH:mm", System.Globalization.CultureInfo.InvariantCulture);
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
                registro.FK_TIPOSERVICIO = usuario.TBL_ROL_USUARIO.First().TBL_ROL.FK_TIPOSERVICIO;//mete 640 en vez de 639
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
                r.TBL_VALOR_CATALOGO = new TBL_VALOR_CATALOGO();
                r.TBL_VALOR_CATALOGO1 = new TBL_VALOR_CATALOGO();
              
               /* foreach (var c in listaCatalogo)
                {
//if (r.TBL_VALOR_CATALOGO==null) {
                        
                       
                  //  }
                    if (r.FK_TIPOSERVICIO == c.FK_CATALOGO) {
                       
                        r.TBL_VALOR_CATALOGO.FK_CATALOGO = c.FK_CATALOGO;
                        r.TBL_VALOR_CATALOGO.VC_VALOR1 = c.VC_VALOR1;
                        r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "0";

                    }
                    if (r.FK_TIPOREGISTRO == c.FK_CATALOGO)
                    {
                       
                        r.TBL_VALOR_CATALOGO1.FK_CATALOGO = c.FK_CATALOGO;
                        r.TBL_VALOR_CATALOGO1.VC_VALOR1 = c.VC_VALOR1;
                        
                    }
                }*/
                foreach (var c in listaConsulta)
                {
                   if (r.PK_REGISTRO==c.FK_REGISTRO ) {
                        r.TBL_VALOR_CATALOGO.VC_VALOR1 = _modelExpediente.Tipo(c.FK_TIPOCEEAMREINGRESO.Value);
                        r.TBL_VALOR_CATALOGO1.VC_VALOR1= _modelExpediente.Tipo(r.FK_TIPOREGISTRO);
                        r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "1";
                    }
                }
                foreach (var a in listaAtencion)
                {
                    if (r.PK_REGISTRO == a.FK_REGISTRO )
                    {
                        r.TBL_VALOR_CATALOGO.VC_VALOR1 = _modelExpediente.Tipo(a.FK_TIPOATENCION);
                        r.TBL_VALOR_CATALOGO1.VC_VALOR1 = _modelExpediente.Tipo(r.FK_TIPOREGISTRO);
                        r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "2";
                    }
                }
                if (r.TBL_VALOR_CATALOGO1.VC_VALOR2 == null) {
                    r.TBL_VALOR_CATALOGO1.VC_VALOR2 = "0";
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

        [AllowAnonymous]
        public JsonResult IsertarDatosUsuaria(FormCollection datos)
        {
            using (var entidades = new SIVIOEntities())
            {
                TBL_PERSONA persona = new TBL_PERSONA();
                TBL_TELEFONO tel = new TBL_TELEFONO();
                persona.VC_NOMBRE = datos["Nombre"];
                persona.VC_APELLIDO1 = datos["Apellido1"];
                persona.VC_APELLIDO2 = datos["Apellido2"];
                persona.FK_NACIONALIDAD = Int32.Parse(datos["Nacionalidad"]);
                persona.FK_NACIONALIDAD2 = Int32.Parse(datos["OtraNacionalidad"]);
                persona.FK_CONDICIONMIGRATORIA = Int32.Parse(datos["CondicionMigratoria"]);
                persona.I_HIJOS = Int32.Parse(datos["NumeroHijos"]);
                persona.I_HIJOSMAYORESDOCE = Int32.Parse(datos["MayorDoce"]);
                persona.FK_DISTRITOPROCEDENCIA = Int32.Parse(datos["DistritoPersona"]);
                persona.FK_CANTONPROCEDENCIA = Int32.Parse(datos["CantonPersona"]);
                persona.FK_PROVINCIAPROCEDENCIA = Int32.Parse(datos["ProvinciaPersona"]);
                persona.FK_ESTADOEMBARAZO = Int32.Parse(datos["MesesEmbarazo"]);
                persona.VC_IDENTIFICACION = datos["Identificacion"];
                persona.DT_FECHANACIMIENTO = Convert.ToDateTime(datos["Fechanacimiento"]);
                entidades.TBL_PERSONA.Add(persona);
                entidades.SaveChanges();
                return Json(new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "Registro Exitoso", "valor"), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Delegacion
        [Authorize]
        public ActionResult Delegacion_Mujer()
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
            return View(viewName: "~/Views/Expediente/Delegacion_Mujer.cshtml");
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