using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIVIO.UI.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult GridUsuarios()
        {
            return View();
        }

        public ActionResult GridRoles()
        {
            return View();
        }
        public ActionResult GridBitácora()
        {
            return View();
        }
        public ActionResult GridTarjetasInteligentes()
        {
            return View();
        }
    }
}