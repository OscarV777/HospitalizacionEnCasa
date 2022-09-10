using System;
using System.Collections.Generic;
using System.Text;

namespace MantenimientoComputadores.Dominio.Entidades
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
