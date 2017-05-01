using SIVIO.Entidades;
using SIVIO.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIVIO.UI.Models
{
    public class SeguridadModel
    {

        #region Bitacora

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
        }

        #endregion

        #region Usuarios

        /// <summary>
        /// Valida usuario y contraseña
        /// </summary>
        /// <param name="clave">contraseña que digitó el usuario</param>
        /// <param name="usuario">entidad usuario producto de la consulta</param>
        /// <returns>resultado booleano</returns>
        public bool ValidarClave(string clave, TBL_USUARIO usuario)
        {

            byte[] claveUsuario = Util.GenerarClave(usuario.VC_USUARIO, clave, 2, usuario.IM_SALT1, usuario.IM_SALT2);
            try
            {
                for (int i = 0; i < claveUsuario.Length; i++)
                {
                    if (usuario.IM_CLAVE[i] != claveUsuario[i])
                        return false;
                }
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Lista todos los usuarios existentes en SIVIO
        /// </summary>
        /// <returns>Lista total de usuarios con roles y acciones</returns>
        public List<TBL_USUARIO> ListarUsuarios()
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    var listaUsuarios = entidades.TBL_USUARIO.ToList();
                    foreach (var usuario in listaUsuarios)
                    {
                        usuario.TBL_ROL_USUARIO = usuario.TBL_ROL_USUARIO;
                        foreach (var asignacion in usuario.TBL_ROL_USUARIO)
                        {
                            asignacion.TBL_ROL = asignacion.TBL_ROL;
                            foreach (var rol in asignacion.TBL_ROL.TBL_ROL_ACCION)
                            {
                                rol.TBL_ACCION = rol.TBL_ACCION;
                            }
                        }

                    }
                    return listaUsuarios;
                }
                catch
                {
                    return new List<TBL_USUARIO>();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public TBL_USUARIO BuscarUsuario(TBL_USUARIO usuario)
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    var usuarioConsulta = entidades.TBL_USUARIO.FirstOrDefault(m => m.VC_USUARIO == usuario.VC_USUARIO.Trim());
                    if (usuarioConsulta != null)
                    {
                        usuarioConsulta.TBL_ROL_USUARIO = usuarioConsulta.TBL_ROL_USUARIO;
                        foreach (var asignacion in usuarioConsulta.TBL_ROL_USUARIO)
                        {
                            asignacion.TBL_ROL = asignacion.TBL_ROL;
                            foreach (var asignacionAccion in asignacion.TBL_ROL.TBL_ROL_ACCION)
                            {
                                asignacionAccion.TBL_ACCION = asignacionAccion.TBL_ACCION;
                            }
                        }

                    }
                    return usuarioConsulta;
                }
                catch
                {
                    return null;
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Mensaje AutenticarUsuario(TBL_USUARIO usuario)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Mensaje ActualizarUsuario(TBL_USUARIO usuario)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Mensaje EliminarUsuario(TBL_USUARIO usuario)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Mensaje AsignarRolesUsuario(TBL_USUARIO usuario)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }

        #endregion

        #region Roles

        public List<TBL_ROL> ListarRoles()
        {
            return new List<TBL_ROL>();
        }

        public List<TBL_ROL> BuscarRoles()
        {
            return new List<TBL_ROL>();
        }

        public Mensaje InsertarRol(TBL_ROL rol)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }
        public Mensaje ActualizarRol(TBL_ROL rol)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }
        public Mensaje EliminarRol(TBL_ROL rol)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }
        public Mensaje AsignarAccionesRol(TBL_ROL rol)
        {
            return new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, "contenido", "valor");
        }

        #endregion

        #region Acciones

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="accion"></param>
        /// <returns></returns>
        public bool ValidarPermisoAccion(string controlador, string accion, TBL_USUARIO usuarioObj)
        {
            /* using (var entidades = new SIVIOEntities())
             {
                 usuarioObj.TBL_ROL_USUARIO = usuarioObj.TBL_ROL_USUARIO;
                 foreach (var rol in usuarioObj.TBL_ROL_USUARIO)
                 {
                     var listaAccionesCoinciden =
                         rol.TBL_ROL.TBL_ROL_ACCION.Where(m => m.TBL_ACCION.VC_CONTROLADOR == controlador && m.TBL_ACCION.VC_ACCION == accion);
                     if (listaAccionesCoinciden.Any())
                         return true;
                 }


             }
             return false;*/
            return true;
        }

        #endregion

        #region Metodos Carga Grid
        #endregion

    }  
}