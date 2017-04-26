using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVIO.Utilitarios
{
    public class Enumerados
    {
        public enum EnumCatalogos
        {
            TipoDocumento = 1,
            Nacionalidad = 2,
            Genero = 3,
            EstadoCivil = 4,
            TipoDiscapacidad = 5,
            PuebloIndigena = 6,
            Ocupacion = 7,
            CondicionesEspeciales = 8,
            TipoTelefono = 9,
            TipoDireccion = 10,
            Idioma = 11,
            JefaturaHogar = 12,
            GradoAcademico = 14,
            CondicionImpideEstudiar = 15,
            Parentesco = 16,
            Beneficio = 17,
            OcasionalidadActEconomica = 18,
            ImpedimentoIngresos = 19,
            TipoRespuestaSituacionViolencia = 20,
            TipoAtencionViolencia = 21,
            AspectoAlimentario = 22,
            TipoParticipacionComunal = 23,
            AnnoGradoAcademico = 24,
            Etnia = 25,
            TipoAyudaAcademico = 26,
            EstadoGradoAcademico = 27,
            TipoProyectiProductivo = 28,
            TipoApoyoProductivo = 29,
            TipoVivienda = 30,
            TipoBonoVivienda = 31,
            TipoEventoBitacora = 32,
            FrecuenciaActividadEconomica = 33,
            TipoViolencia = 34,
            RespuestaSiNosponible = 36,
            TomaDesicionesHogar = 38,
            TipoAyudaIMAS = 39,
            TipoDesicionHogar = 40,
            Adiccion = 41,
            SituacionMigratoria = 42,
            SituacionLaboral = 43,
            Padecimiento = 44,
            TipoFamilia = 45,
            Embarazo = 46,
            MotivoIngreso = 48,
            NumeroSeparacionesAgresor = 49,
            MotivoReanudarRelacionAgresor = 50,
            TipoAtencionMedica = 51,
            SituacionViolenciaFisica = 52,
            SituacionViolenciaPsicologica = 53,
            SituacionViolenciaSexual = 54,
            SituacionViolenciaPatrimonial = 55,
            ImpactoProductoViolencia = 56,
            MedidaProteccion = 58,
            PersonaInstucionRefiere = 59,
            SituacionEnfrentada = 60,
            TipoVinculoRelación = 62,
            SituacionRiesgo = 63,
            CategoriaRiesgo = 64,
            TipoServicio = 65,
            TipoDisponibilidad = 96
        }

        public enum Roles
        {
            Administradora = 3,
            Facilitadora = 4
        }

        public enum TiposEventoBitacora
        {
            IngresoSistema = 253,
            ConsultaInformación = 254,
            RegistroNuevaInformacion = 255,
            ActualizacionInformación = 256,
            ExtraccionMasivaDatos = 314,
            SolicitudReporte = 315,
            CreacionUsuario = 317,
            CreacionRol = 318,
            EdicionUsuario = 319,
            EdicionRol = 320,
            CreacionGrupo = 321,
            EdicionGrupo = 322,
            ErrorCapaPresentación = 540,
            ErrorCapaAccesoDatos = 541,
            OtroTipoError = 542
        }

        public enum TipoMenu
        {
            DelegacionUnidadesRegionales = 634,
            CEAAM = 635,
            COAVIFEquipoEstrategico = 637,
            AdministracionSIVIO = 638
        }
    }
}
