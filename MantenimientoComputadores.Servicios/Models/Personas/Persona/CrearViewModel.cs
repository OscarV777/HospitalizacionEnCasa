using MantenimientoComputadores.Dominio.Entidades;

namespace MantenimientoComputadores.Servicios.Models.Personas.Persona
{
    public class CrearViewModel
    {
        
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public int TarjetaProfecional { get; set; }


        public string Password { get; set; }
        public bool Condicion { get; set; }
    }
}
