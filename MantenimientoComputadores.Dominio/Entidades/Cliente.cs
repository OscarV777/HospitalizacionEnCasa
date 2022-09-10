using System;
using System.Collections.Generic;

namespace MantCompu.App.Dominio
{
    /// <summary>Class <c>Cliente</c>
    /// Modela un Cliente en general en el sistema
    /// </summary>
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public ICollection <Cita> Citas { get; set; }
        
    }
}