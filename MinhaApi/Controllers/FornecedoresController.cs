using MinhaApi.Models;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Services;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController(Services.IFornecedorService service) : ControllerBase
    {
        private readonly Services.IFornecedorService _service = service;
        private string cnpj = "";

        // GET /api/Fornecedores
        [HttpGet]
        public IActionResult GetAll()
        {
            var fornecedores = _service.GetAll();
            return Ok(fornecedores);
        }

        // GET /api/Fornecedores/cnpj/12345678901234
        [HttpGet("{cnpj}")]
        public IActionResult GetByCnpj(string cnpj)
        {
            var fornecedor = _service.GetById(cnpj);

            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        // GET /api/Fornecedores/nome/FornecedorTeste
        [HttpGet("nome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var fornecedor = _service.GetByNome(nome);

            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        // POST /api/Fornecedores
        [HttpPost]
        public IActionResult Create([FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var criado = _service.Create(fornecedor);

            return CreatedAtAction(
                nameof(GetByCnpj),
                new { cnpj = criado.Cnpj},
                criado
            );
        }

        // PUT /api/Fornecedores/12345678901234
        [HttpPut("{cnpj}")]
        public IActionResult Update(
            string cnpj,
            [FromBody] Fornecedor fornecedor)
        {
            var atualizado = _service.Update(cnpj, fornecedor);

            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

        // DELETE /api/Fornecedores/12345678901234
        [HttpDelete("{cnpj}")]
        public IActionResult Delete(string cnpj)
        {
            var deletado = _service.Delete(cnpj);

            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }
}