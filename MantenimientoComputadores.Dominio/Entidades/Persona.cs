using MantenimientoComputadores.Dominio.Entidades;
using System;

namespace MantCompu.App.Dominio
{
    /// <summary>Class <c>Persona</c>
    /// Modela una Persona en general en el sistema
    /// </summary>
    public class Persona 
    {
        // Identificador único de cada persona
        public int PersonaId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int  RolId { get; set; }
        public Rol Rol { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public bool Condicion { get; set; }


    }
}