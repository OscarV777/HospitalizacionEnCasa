using MantCompu.App.Dominio;
using MantenimientoComputadores.Dominio.Entidades;
using System;

namespace MantenimientoComputadores.Servicios.Models
{
    public class CitaViewModel
    {
        public int CitaId { get; set; }
        ///Relacion entre la cita y el cliente que lo solicita
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        ///Relacion entre la cita y el tecnico que lo atiende
        public int AgendaId { get; set; }
        public string FechaInicioProgramada { get; set; }
        public string FechaFinalProgramada { get; set; }
        public string NombreTecnico { get; set; }

        ///Relacion entre la cita y el tipo de servicio solicitado
        public int TipoServicioId { get; set; }
        public string TipoServicio { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        
    }
}
