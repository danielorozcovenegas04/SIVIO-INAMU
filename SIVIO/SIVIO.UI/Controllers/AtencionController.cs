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

        #region Modelos
        SIVIO.UI.Models.CatalogosModel _modelCatalogos = new Models.CatalogosModel();
        #endregion

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

        [AllowAnonymous]
        public JsonResult ListarCatalogosAtenciones()
        {
            List<int> catalogos = new List<int>()
            {
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoAtencion               
            };
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_modelCatalogos.llenarListaCatalogos(catalogos)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Atenciones()
        {
            return View();
        }
    }
}








