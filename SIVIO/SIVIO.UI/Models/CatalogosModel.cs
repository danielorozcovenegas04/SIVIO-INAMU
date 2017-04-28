using EFJson;
using SIVIO.Entidades;
using SIVIO.InamuComun;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SIVIO.UI.Models
{
    public class CatalogosModel
    {
        public TBL_CATALOGO ObtenerCatalogoPorId(int idCatalogo)
        {
            using (var entidades = new SIVIOEntities())
            {
                var catalogoConsulta = entidades.TBL_CATALOGO.FirstOrDefault(m => m.PK_CATALOGO == idCatalogo);
                if (catalogoConsulta != null)
                {
                    catalogoConsulta.TBL_VALOR_CATALOGO = catalogoConsulta.TBL_VALOR_CATALOGO;
                }
                return catalogoConsulta;
            }
        }
        public dynamic RetornarOrganizacionTerritorial()
        {
            using (var modeloComun = new INAMU_COMUNEntities())
            {
                var listaProvincias = modeloComun.CAT_PROVINCIA.ToArray();
                var listaCantones = modeloComun.CAT_CANTON.ToArray();
                var listaDistritos = from distrito in modeloComun.CAT_DISTRITO
                                     select new
                                     {
                                         I_IDDISTRITO = distrito.I_IDDISTRITO,
                                         I_IDPROVINCIA = distrito.I_IDPROVINCIA,
                                         I_IDCANTON = distrito.I_IDCANTON,
                                         VC_DESCRIPCION = distrito.VC_DESCRIPCION,
                                         I_IDREGION = distrito.CAT_REGION.I_IDREGION
                                     };
                var listaRegiones = modeloComun.CAT_REGION.ToArray();
                dynamic objDivisionTerritorial = new ExpandoObject();
                objDivisionTerritorial.Provincias = listaProvincias.Select(c => JsonHelper.ConvertToSimpleObject(c));
                objDivisionTerritorial.Cantones = listaCantones.Select(c => JsonHelper.ConvertToSimpleObject(c));
                objDivisionTerritorial.Distritos = listaDistritos.ToArray().Select(c => JsonHelper.ConvertToSimpleObject(c));
                objDivisionTerritorial.Regiones = listaRegiones.Select(c => JsonHelper.ConvertToSimpleObject(c));

                return objDivisionTerritorial;
            }
        }
    }
}