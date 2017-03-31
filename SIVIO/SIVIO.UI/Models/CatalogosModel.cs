using SIVIO.Entidades;
using System;
using System.Collections.Generic;
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
                    catalogoConsulta.TBL_VALORCATALOGO = catalogoConsulta.TBL_VALORCATALOGO;
                }
                return catalogoConsulta;
            }
        }
    }
}