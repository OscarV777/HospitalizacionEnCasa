using System;

namespace MantCompu.App.Dominio
{
    /// <summary>Class <c>Administrador</c>
    /// Modela un Administrador en general en el sistema
    /// </summary>
    public class Administrador 
    {
        public int AdministradorId { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        
    }
}