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
        CatalogosModel _modelCatalogo = new CatalogosModel();

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

        [Authorize]
        public ActionResult CrearAtencionesPsicologiaAdultas(int persona)
        {
            return View();
        }

        [Authorize]
        public ActionResult ListarCatalogosPsicologiaAdulta()
        {
            List<int> catalogos = new List<int>()
            {
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoAsesoriaAdultas,
                (int)Utilitarios.Enumerados.EnumCatalogos.TipoDeGrupoIntervencionGrupal
            };
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(_modelCatalogo.llenarListaCatalogos(catalogos)), JsonRequestBehavior.AllowGet);
        }
    }
}








