using ExercicioPermissao.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioPermissao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return _usuarios;
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            _usuarios.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult<Usuario> Put(int id, [FromBody] Usuario usuario)
        {
            var existingUsuario = _usuarios.FirstOrDefault(x => x.Id == id);
            if (existingUsuario == null)
            {
                return NotFound();
            }
            existingUsuario.Nome = usuario.Nome;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Login = usuario.Login;
            existingUsuario.Senha = usuario.Senha;
            existingUsuario.Regra = usuario.Regra;
            return Ok(existingUsuario);
        }

        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            var existingUsuario = _usuarios.FirstOrDefault(x => x.Id == id);
            if (existingUsuario == null)
            {
                return NotFound();
            }
            _usuarios.Remove(existingUsuario);
            return Ok(existingUsuario);
        }
    }
}