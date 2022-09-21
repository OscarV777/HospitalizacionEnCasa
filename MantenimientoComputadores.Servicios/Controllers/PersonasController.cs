using MantCompu.App.Dominio;
using MantenimientoComputadores.Persistencia.AppRepositorios;
using MantenimientoComputadores.Servicios.Models.Personas.Persona;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MantenimientoComputadores.Servicios.Controllers
{
    
    [Route("api/Personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        
        public MantenimientoContext appContext;

        public PersonasController()
        {
            appContext = new MantenimientoContext();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numeroDocumento = model.NumeroDocumento;
            if (await appContext.Personas.AnyAsync(u => u.NumeroDocumento == numeroDocumento))
            {
                return BadRequest("El Usuario ya se encuentra Registrado en el sistema");

            }

            CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Persona usuario = new Persona
            {
                RolId = model.RolId,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Email= model.Email,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                password_hash = passwordHash,
                password_salt = passwordSalt,
                Condicion = true
            };

            appContext.Personas.Add(usuario);
            try
            {
                await appContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            var rol = await appContext.Roles.Where(r => r.RolId == model.RolId).FirstOrDefaultAsync();
            if (rol != null)
            {
                if (rol.Nombre == "Tecnico")
                {
                    var tarjetaProfesional = model.TarjetaProfecional;
                    if (await appContext.Tecnicos.AnyAsync(u => u.TarjetaProfesional == tarjetaProfesional))
                    {
                        return BadRequest("El Nuemero de tarjeta profesional ya se encuentra Registrado en el sistema");

                    }
                    Tecnico tecnico = new Tecnico
                    {
                        PersonaId = usuario.PersonaId,
                        TarjetaProfesional = model.TarjetaProfecional

                    };

                    appContext.Tecnicos.Add(tecnico);
                    try
                    {
                        await appContext.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    if (rol.Nombre == "Cliente")
                    {
                        Cliente cliente = new Cliente
                        {
                            PersonaId = usuario.PersonaId,
                            

                        };
                        appContext.Clientes.Add(cliente);
                        try
                        {
                            await appContext.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            return BadRequest();
                        }
                    }

                }
            }
            return Ok();
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }
        
    }
}
