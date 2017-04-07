using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SIVIO.UI.Controllers
{
    public class SeguridadController : BaseController
    {
        // GET: Seguridad
        [Authorize]
        public ActionResult GridUsuarios()
        {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View();
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
        public ActionResult GridRoles()
        {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View();
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
        public ActionResult GridBitácora()
        {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View();
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
        public ActionResult GridTarjetasInteligentes()
        {
            bool estadoSesion = true;
            if (ComprobarPermisosAcccion(out estadoSesion))
            {
                return View();
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

        [AllowAnonymous]
        public bool CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return true;
        }
    }
}