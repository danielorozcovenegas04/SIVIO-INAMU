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

        #endregion
    }
}