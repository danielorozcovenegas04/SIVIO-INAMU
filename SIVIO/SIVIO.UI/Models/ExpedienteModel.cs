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
        public List<TBL_CONSULTA> ListarConsultas(int persona)
        {
            using (var entidades = new SIVIOEntities())
            {

                try
                {
                    var personaConsulta = entidades.TBL_PERSONA.FirstOrDefault(p => p.PK_PERSONA == persona);
                    if (personaConsulta != null)
                    {
                        return personaConsulta
                            .TBL_REGISTRO.Select(r => r.TBL_CONSULTA) // tomar las consultas de cada registro asociado a la persona
                            .SelectMany(i => i) // aplanar la lista de lista de consultas
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

        #region COAVIF
        public List<TBL_PERSONA> ListarPersonas() {

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

        #endregion

        #region DELEGACION
        public Mensaje InsertarUsuaria(TBL_PERSONA usuaria)
        {
            //return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
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

        public DateTime fecha { get; set; }
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