using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIVIO.Entidades;
using SIVIO.Utilitarios;
using System.Data;

namespace SIVIO.UI.Models
{
    public class ExpedienteModel
    {
        public List<TBL_CONSULTA> ListarConsultas(int persona)
        {
            using (var entidades = new SIVIOEntities())
            {

                try
                {
                    var personaConsulta = entidades.TBL_PERSONA.FirstOrDefault(p => p.PK_PERSONA == persona);
                    if (personaConsulta != null)
                    {
                        return personaConsulta
                            .TBL_REGISTRO.Select(r => r.TBL_CONSULTA) // tomar las consultas de cada registro asociado a la persona
                            .SelectMany(i => i) // aplanar la lista de lista de consultas
                            .ToList(); // convertirlo a una lista
                    }
                    else
                    {
                        return new List<TBL_CONSULTA>();
                    }
                }
                catch
                {
                    return new List<TBL_CONSULTA>();
                }
            }
        }
        
        public List<TBL_REGISTRO> ListarRegistros(int persona)
        {
            using (var entidades = new SIVIOEntities())
            {
                try
                {
                    var personaConsulta = entidades.TBL_PERSONA.Find(persona);
                    if(personaConsulta != null)
                    {
                        return personaConsulta.TBL_REGISTRO.ToList();
                    } else
                    {
                        return new List<TBL_REGISTRO>();
                    }
                }
                catch
                {
                    return new List<TBL_REGISTRO>();
                }
            }
        }

        public List<TBL_PERSONA> ListarPersonas(string palabra) {
            System.Diagnostics.Debug.WriteLine(palabra);
            using (var entidades = new SIVIOEntities()) {
                try {
                    List<TBL_PERSONA> personaConsulta = entidades.TBL_PERSONA
                        .Where(m => (m.VC_NOMBRE + " " + m.VC_APELLIDO1 + " " + m.VC_APELLIDO2 + " " + m.VC_IDENTIFICACION)
                        .Trim().Contains(palabra.Trim())).ToList();
                    return personaConsulta;
                } catch {
                    return new List<TBL_PERSONA>();
                }
            }
        }
    }
}