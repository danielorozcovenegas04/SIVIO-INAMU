using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIVIO.Entidades;
using SIVIO.Utilitarios;
using System.Data;

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


        /*
        public Mensaje InsertarUsuario(TBL_USUARIO usuario)
        {
            //return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
            using (var entidades = new SIVIOEntities())
            {
                TBL_USUARIO usuarioActual = (TBL_USUARIO)HttpContext.Current.Application["usuarioActual"];
                try
                {
                    entidades.TBL_USUARIO.Add(usuario);
                    usuario.DT_FECHAREGISTRO = DateTime.Now;
                    entidades.SaveChanges();

                    RegistrarBitacora(new TBL_BITACORA
                    {
                        DT_FECHAEVENTO = DateTime.Now,
                        FK_TIPOEVENTO = (int)Enumerados.TiposEventoBitacora.CreacionUsuario,
                        FK_USUARIO = usuarioActual.PK_USUARIO,
                        VC_DETALLE = usuario.PK_USUARIO.ToString(),
                        VC_DIRECCIONIP = string.Empty
                    });
                    return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "Usuario Registrado Correctamente", "valor");
                }
                catch (Exception e)
                {
                    RegistrarBitacora(new TBL_BITACORA
                    {
                        DT_FECHAEVENTO = DateTime.Now,
                        FK_TIPOEVENTO = (int)Enumerados.TiposEventoBitacora.ErrorCapaAccesoDatos,
                        FK_USUARIO = usuarioActual.PK_USUARIO,
                        VC_DETALLE = e.Message.ToString(),
                        VC_DIRECCIONIP = string.Empty
                    });
                    return new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error al registrar usuario", "valor");
                }

            }
        } */
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