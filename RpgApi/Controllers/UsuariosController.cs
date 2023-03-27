using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {



        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }
        
        [HttpPost("GetUser")]
        public async Task<IActionResult> Get(Usuario u)
        {
            try
            {
                Usuario uRetornado = await _context.Usuarios.FirstOrDefaultAsync(x => x.Username == u.Username && x.Email == u.Email);
               
                if(uRetornado == null)
                throw new Exception("Usuário não encontrado");
                
                return Ok(uRetornado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}