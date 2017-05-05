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

        public dynamic llenarListaCatalogos(List<int> catalogos)
        {
            var objCatalogo = new ExpandoObject() as IDictionary<string, Object>;

            foreach (var catalogo in catalogos)
            {
                dynamic objetoRetorno = new ExpandoObject();
                string nombre = null;
                try
                {
                    objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Exitoso, string.Empty, string.Empty);
                    objetoRetorno.Catalogo = this.ObtenerCatalogoPorId(catalogo)
                        .TBL_VALOR_CATALOGO
                        .Select(m => new { m.PK_VALORCATALOGO, m.VC_VALOR1, m.VC_VALOR2 });

                    nombre = this.ObtenerCatalogoPorId(catalogo).VC_NOMBRECATALOGO;

                }
                catch (Exception e)
                {
                    objetoRetorno.Mensaje = new Mensaje((int)Mensaje.CatTipoMensaje.Error, "Error al cargar tipos de servicio", e.ToString());
                }

                if (nombre != null)
                {
                    objCatalogo.Add(nombre, objetoRetorno);
                }

            }

            return objCatalogo;
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