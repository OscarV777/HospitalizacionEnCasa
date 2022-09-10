using MantenimientoComputadores.Dominio.Entidades;
using System;

namespace MantCompu.App.Dominio
{
    /// <summary>Class <c>Cita</c>
    /// Modela una Cita en general en el sistema
    /// </summary>
    public class Cita
    {
        public int CitaId { get; set; }
        ///Relacion entre la cita y el cliente que lo solicita
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        ///Relacion entre la cita y el tecnico que lo atiende
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }
        
        ///Relacion entre la cita y el tipo de servicio solicitado
        public TipoServicio TipoServicio { get; set; }
        public int TipoServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
    }
}