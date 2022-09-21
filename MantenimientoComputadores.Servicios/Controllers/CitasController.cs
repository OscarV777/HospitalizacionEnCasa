using MantenimientoComputadores.Persistencia.AppRepositorios;
using MantenimientoComputadores.Servicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MantenimientoComputadores.Servicios.Controllers
{
    [Route("api/Citas")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        MantenimientoContext appContext;
        // GET: api/<CitasController>
        public CitasController()
        {
            appContext = new MantenimientoContext(); 
        }
        [HttpGet("{id}")]
        public async Task <IEnumerable<CitaViewModel>> ObtenerServicioPorTecnico(int id)
        {
            var servicios = await appContext.Citas
                .Include(ca => ca.Agenda)
                    .ThenInclude(at => at.Tecnico)
                        .ThenInclude(tp => tp.Persona)
                .Include(cc => cc.Cliente) 
                    .ThenInclude(cp => cp.Persona)
                .Include(ce => ce.Estado)
                .Include(ct => ct.TipoServicio)                
                .Where(at => at.Agenda.TecnicoId == id && at.Estado.Nombre == "Asignado" ).ToListAsync();
                    
            return servicios.Select(s => new CitaViewModel{
                CitaId = s.CitaId,
                ClienteId = s.ClienteId,
                NombreCliente = s.Cliente.Persona.Nombre,
                AgendaId = s.AgendaId,
                FechaInicioProgramada = s.Agenda.FechaInicio.ToString(),
                FechaFinalProgramada = s.Agenda.FechaFinal.ToString(),
                NombreTecnico = s.Agenda.Tecnico.Persona.Nombre,
                TipoServicioId = s.TipoServicioId,
                TipoServicio = s.TipoServicio.Nombre,
                EstadoId = s.EstadoId,
                Estado = s.Estado.Nombre
            });

        }

        
    }
}
