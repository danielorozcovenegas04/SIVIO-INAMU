using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIVIO.UI.Controllers
{
    public class CatalogosController : Controller
    {
        #region Modelos
        SIVIO.UI.Models.CatalogosModel _modelCatalogos = new Models.CatalogosModel();
        #endregion


        [AllowAnonymous]
        public JsonResult RetornarDivisionTerritorial()
        {
            try
            {
                return Json(_modelCatalogos.RetornarOrganizacionTerritorial(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error al procesar la solicitud: " + e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: Catalogos
        public ActionResult Index()
        {
            return View();
        }
    }
}