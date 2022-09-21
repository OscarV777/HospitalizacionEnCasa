using MantCompu.App.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MantenimientoComputadores.Dominio.Entidades
{
    public class Rol
    {
        public int RolId { get; set; }
        public string   Nombre { get; set; }    
        public string   Descricion { get; set; }
        public bool  Condicion { get; set; }
        public ICollection<Persona> personas { get; set; }


    }
}
