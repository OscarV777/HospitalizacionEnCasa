using System;

namespace MantCompu.App.Dominio
{
    /// <summary>Class <c>TipoServicio</c>
    /// Modela un Tipo de Servicio en general en el sistema
    /// </summary>
    public class TipoServicio
    {
        public int TipoServicioId { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
    }
}
