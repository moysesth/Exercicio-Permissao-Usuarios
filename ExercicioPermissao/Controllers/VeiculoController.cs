using ExercicioPermissao.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioPermissao.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private static List<Veiculo> _veiculos = new List<Veiculo>();

        [HttpGet]
        public ActionResult<IEnumerable<Veiculo>> Get()
        {
            return _veiculos;
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> Get(int id)
        {
            var veiculo = _veiculos.FirstOrDefault(x => x.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return veiculo;
        }

        [HttpPost]
        public ActionResult<Veiculo> Post([FromBody] Veiculo veiculo)
        {
            _veiculos.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public ActionResult<Veiculo> Put(int id, [FromBody] Veiculo veiculo)
        {
            var existingVeiculo = _veiculos.FirstOrDefault(x => x.Id == id);
            if (existingVeiculo == null)
            {
                return NotFound();
            }
            existingVeiculo.Nome = veiculo.Nome;
            existingVeiculo.Descricao = veiculo.Descricao;
            existingVeiculo.Marca = veiculo.Marca;
            existingVeiculo.Modelo = veiculo.Modelo;
            existingVeiculo.Ano = veiculo.Ano;
            return Ok(existingVeiculo);
        }

        [HttpDelete("{id}")]
        public ActionResult<Veiculo> Delete(int id)
        {
            var existingVeiculo = _veiculos.FirstOrDefault(x => x.Id == id);
            if (existingVeiculo == null)
            {
                return NotFound();
            }
            _veiculos.Remove(existingVeiculo);
            return Ok(existingVeiculo);
        }
    }
}
