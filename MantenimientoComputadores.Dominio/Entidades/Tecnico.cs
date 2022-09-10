using MantenimientoComputadores.Dominio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MantCompu.App.Dominio
{
    /// <summary>Class <c>Tecnico</c>
    /// Modela un Tecnico en general en el sistema
    /// </summary>
    public class Tecnico 
    {   
        public int TecnicoId { get; set; }
        public int TarjetaProfesional { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
    }
}