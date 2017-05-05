using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIVIO.Entidades;
using SIVIO.Utilitarios;
using System.Data;
using System.Data.Entity.Validation;

namespace SIVIO.UI.Models
{
    public class ExpedienteModel
    {
        public List<TBL_CONSULTA> ListarConsultas(Guid caso)
        {
            using (var entidades = new SIVIOEntities())
            {

                try
                {
                    var casoConsulta = entidades.TBL_REGISTRO.FirstOrDefault(c => c.PK_REGISTRO == caso);
                    if (casoConsulta != null)
                    {
                        return casoConsulta
                            .TBL_CONSULTA // tomar consultas del caso
                            .ToList(); // convertirlo a una lista
                    }
                    else
                    {
                        return new List<TBL_CONSULTA>();
                    }
                }
                catch
                {
                    return new List<TBL_CONSULTA>();
                }
            }
        }
        
        public List<TBL_REGISTRO> ListarRegistros(int persona)
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    var personaConsulta = entidades.TBL_PERSONA.Find(persona);
                    if(personaConsulta != null)
                    {
                        return personaConsulta.TBL_REGISTRO.ToList();
                    } else
                    {
                        return new List<TBL_REGISTRO>();
                    }
                }
                catch
                {
                    return new List<TBL_REGISTRO>();
                }
            }
        }

        public List<TBL_PERSONA> ListarPersonas(string palabra) {
            System.Diagnostics.Debug.WriteLine(palabra);
            using (var entidades = new SIVIOEntities()) {
                try {
                    List<TBL_PERSONA> personaConsulta = entidades.TBL_PERSONA
                        .Where(m => (m.VC_NOMBRE + " " + m.VC_APELLIDO1 + " " + m.VC_APELLIDO2 + " " + m.VC_IDENTIFICACION)
                        .Trim().Contains(palabra.Trim())).ToList();
                    return personaConsulta;
                } catch {
                    return new List<TBL_PERSONA>();
                }
            }
        }

        public List<SP_BUSCAR_EXPEDIENTE_CEEAM_Result> BuscarExpedienteCEAAM(string frase)
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    return entidades.SP_BUSCAR_EXPEDIENTE_CEEAM(frase).ToList();
                }
                catch
                {
                    return new List<SP_BUSCAR_EXPEDIENTE_CEEAM_Result>();
                }
            }
        }
        public TBL_PERSONA ObtenerPersona(string persona)
        {
           
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    TBL_PERSONA personaConsulta = (TBL_PERSONA)entidades.TBL_PERSONA.Find(Int32.Parse(persona)); //Where(m => m.PK_PERSONA == Int32.Parse(persona));// .Where(m => m.PK_PERSONA == Int32.Parse(persona));
                    //TBL_REGISTRO_CEAAM = 
                  /*  TBL_ADICCIONES adiciones                        = entidades.TBL_ADICCIONES.Find(personaConsulta.PK_PERSONA);
                    TBL_AGRESOR agresor                             = entidades.TBL_AGRESOR.Find(personaConsulta.PK_PERSONA);
                    TBL_DIRECCION direccion                         = entidades.TBL_DIRECCION.Find(personaConsulta.PK_PERSONA);
                    TBL_LABORAL laboral                             = entidades.TBL_LABORAL.Find(personaConsulta.PK_PERSONA); 
                    TBL_PERSONA_APOYO apoyo                         = entidades.TBL_PERSONA_APOYO.Find(personaConsulta.PK_PERSONA); 
                    TBL_PERSONA_CONDICIONESPECIAL condicionEspecial = entidades.TBL_PERSONA_CONDICIONESPECIAL.Find(personaConsulta.PK_PERSONA); 
                    TBL_PERSONA_RED_APOYO redApoyo                  = entidades.TBL_PERSONA_RED_APOYO.Find(personaConsulta.PK_PERSONA); 
                    TBL_PERSONA_SALUD salud                         = entidades.TBL_PERSONA_SALUD.Find(personaConsulta.PK_PERSONA); 
                    TBL_REGISTRO registro                           = entidades.TBL_REGISTRO.Find(personaConsulta.PK_PERSONA); 
                    TBL_TELEFONO telefono                           = entidades.TBL_TELEFONO.Find(personaConsulta.PK_PERSONA); 

                    personaConsulta.TBL_ADICCIONES = (TBL_PERSONA)adiciones;*/

                    return personaConsulta;
                }
                catch (Exception ex)
                {
                    return new TBL_PERSONA();
                }
            }
        }

        public void InsertarPersonaConAgresor(
            TBL_PERSONA persona,            TBL_AGRESOR agresor,
            TBL_LABORAL laboral,            TBL_ADICCIONES adicciones,
            TBL_PERSONA_RED_APOYO apoyo1,   TBL_AGRESION agresion,
            TBL_AGRESOR_MOTIVO_REGRESO agresorMotivoRegreso, TBL_AGRESION_ATENCION_MEDICA agresionAtencionMedica)
        {
            using (var entidades = new SIVIOEntities())
            {
                entidades.Entry(agresor).State = System.Data.Entity.EntityState.Added;
                entidades.Entry(persona).State = System.Data.Entity.EntityState.Added;
                entidades.Entry(laboral).State = System.Data.Entity.EntityState.Added;
                entidades.Entry(adicciones).State = System.Data.Entity.EntityState.Added;
                //entidades.Entry(apoyo1).State = System.Data.Entity.EntityState.Added;
                entidades.Entry(agresion).State = System.Data.Entity.EntityState.Added;
                entidades.Entry(agresorMotivoRegreso).State = System.Data.Entity.EntityState.Added;
                entidades.Entry(agresionAtencionMedica).State = System.Data.Entity.EntityState.Added;

                entidades.SaveChanges();
            }
        }

        public DateTime fecha { get; set; }
        public string hora { get; set; }
        #region COAVIF
        public List<TBL_PERSONA> ListarPersonas()
        {

            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_PERSONA> personaConsulta = entidades.TBL_PERSONA.ToList();
                    return personaConsulta;
                }
                catch
                {
                    return new List<TBL_PERSONA>();
                }
            }
        }
        public List<TBL_USUARIO> ListarUSuarios()
        {

            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_USUARIO> usuarioConsulta = entidades.TBL_USUARIO.ToList();
                    return usuarioConsulta;
                }
                catch
                {
                    return new List<TBL_USUARIO>();
                }
            }
        }

        public List<TBL_ROL> ListarRoles()
        {

            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_ROL> rolConsulta = entidades.TBL_ROL.ToList();
                    return rolConsulta;
                }
                catch
                {
                    return new List<TBL_ROL>();
                }
            }
        }

        public List<TBL_ROL_USUARIO> ListarUSuariosRoles()
        {

            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_ROL_USUARIO> rolUsuarioConsulta = entidades.TBL_ROL_USUARIO.ToList();
                    return rolUsuarioConsulta;
                }
                catch
                {
                    return new List<TBL_ROL_USUARIO>();
                }
            }
        }
        public List<TBL_CONSULTA> ListarConsultas()
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_CONSULTA> Consulta = entidades.TBL_CONSULTA.ToList();
                    return Consulta;
                }
                catch
                {
                    return new List<TBL_CONSULTA>();
                }
            }
        }

        public TBL_PERSONA BuscarPersona(int idPersona)
        {
            var entidades = new SIVIOEntities();

            try
            {
                var p = new TBL_PERSONA();
                TBL_PERSONA persona = entidades.TBL_PERSONA.Find(idPersona);
                if(persona != null)
                return persona;
                else
                return new TBL_PERSONA();
            }
            catch (Exception e)
            {
                return new TBL_PERSONA();
            }
        }

        public Mensaje InsertarDatosAdministrativos(TBL_REGISTRO registro)
        {//parametro que recibe de la vista
            try
            {
                using (var entidades = new SIVIOEntities())
                {
                    entidades.TBL_REGISTRO.Add(registro);
                    entidades.SaveChanges();
                }
                return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
            }
            catch (Exception e)
            {
                return new Mensaje((int)Mensaje.CatTipoMensaje.Error, string.Empty, string.Empty);
            }
        }

        #endregion

        #region DELEGACION
        /* //Método RegistrarBitácora, vital para insertar usuario.
        public static Mensaje RegistrarBitacora(TBL_BITACORA bitacora)
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    entidades.TBL_BITACORA.Add(bitacora);
                    entidades.SaveChanges();
                    return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "Bitacora Registrada exitosamente", string.Empty);
                }
                catch
                {
                    return new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Fallo al registrar bitacora", string.Empty);
                }
            }
        }*/


        public List<TBL_ATENCION> ListarAtencion()
        {

            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_ATENCION> Atencion = entidades.TBL_ATENCION.ToList();
                    return Atencion;
                }
                catch
                {
                    return new List<TBL_ATENCION>();
                }
            }
        }

        public List<TBL_REGISTRO> ListarRegistro()
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_REGISTRO> Registro = entidades.TBL_REGISTRO.ToList();
                    return Registro;
                    /* List<TBL_REGISTRO> R = new List<TBL_REGISTRO>();
                     R.Add(new TBL_REGISTRO()
                     {
                         PK_REGISTRO = Guid.NewGuid(),
                         FK_PERSONA = 5,
                         FK_USUARIOREGISTRA = 7,
                         DT_FECHAINICIO = DateTime.Now,
                         DT_FECHAFIN = DateTime.Now,
                         FK_TIPOSERVICIO = 4,
                         FK_TIPOREGISTRO = 549,
                         VC_OBSERVACIONES = "algo"
                     });
                     R.Add(new TBL_REGISTRO()
                     {
                         PK_REGISTRO = Guid.NewGuid(),
                         FK_PERSONA = 6,
                         FK_USUARIOREGISTRA = 3,
                         DT_FECHAINICIO = DateTime.Now,
                         DT_FECHAFIN = DateTime.Now,
                         FK_TIPOSERVICIO = 69,
                         FK_TIPOREGISTRO = 550,
                         VC_OBSERVACIONES = "algo"
                     });
                     return R;*/
                }
                catch
                {
                    return new List<TBL_REGISTRO>();
                    /* List<TBL_REGISTRO> R = new List<TBL_REGISTRO>();
                     R.Add(new TBL_REGISTRO()
                     {
                         //PK_REGISTRO = 2,
                         FK_PERSONA = 5,
                         FK_USUARIOREGISTRA = 7,
                         DT_FECHAINICIO = DateTime.Now,
                         DT_FECHAFIN = DateTime.Now,
                         FK_TIPOSERVICIO = 4,
                         FK_TIPOREGISTRO = 47,
                         VC_OBSERVACIONES = "algo"
                     });
                     R.Add(new TBL_REGISTRO()
                     {
                         //PK_REGISTRO = 2,
                         FK_PERSONA = 6,
                         FK_USUARIOREGISTRA = 3,
                         DT_FECHAINICIO = DateTime.Now,
                         DT_FECHAFIN = DateTime.Now,
                         FK_TIPOSERVICIO = 69,
                         FK_TIPOREGISTRO = 69,
                         VC_OBSERVACIONES = "algo"
                     });
                     return R;*/
                }

            }

        }


        public List<TBL_VALOR_CATALOGO> ListarCatalogo()
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    List<TBL_VALOR_CATALOGO> Catalogo = entidades.TBL_VALOR_CATALOGO.ToList();
                    return Catalogo;
                }
                catch
                {
                    return new List<TBL_VALOR_CATALOGO>();
				}
			}
		}
		
		public Mensaje InsertarUsuaria(TBL_PERSONA usuaria)
        {
            using (var entidades = new SIVIOEntities())
            {
                TBL_PERSONA usuarioActual = (TBL_PERSONA)HttpContext.Current.Application["usuarioActual"];
                try
                {
                    entidades.TBL_PERSONA.Add(usuaria);
                    //  usuaria.DT_FECHAREGISTRO = DateTime.Now;   // CONSULTAR 
                    entidades.SaveChanges();

                    return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "Usuaria Registrada Correctamente", "valor");
                }

                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    //    throw;
                    return new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error al registrar usuaria", "valor");
                }
            }
        }

        public string horaInicio { get; set; }
        public string horaFinal { get; set; }
        public string institucionRefiere { get; set; }
        public string personaRefiere { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string tipoAtension { get; set; }
        #endregion
    }
}