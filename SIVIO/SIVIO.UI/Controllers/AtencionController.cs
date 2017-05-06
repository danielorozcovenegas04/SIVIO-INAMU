using SIVIO.Entidades;
using SIVIO.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SIVIO.UI.Models.ExpedienteModel;

namespace SIVIO.UI.Controllers
{
    public class AtencionesController : BaseController
    {

        ExpedienteModel _modelExpediente = new ExpedienteModel();
        // GET: Atenciones
        public ActionResult Index()
        {
            return View();
        }

        // GET: Seguridad
        [Authorize]
        public ActionResult GridAtenciones()
        {

                return View(_modelExpediente.ListarAtencionesGrid());

        }
    }
}








