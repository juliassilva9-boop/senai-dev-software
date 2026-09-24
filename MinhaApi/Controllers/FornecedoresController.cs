using MinhaApi.Models;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Services;


[ApiController]
[Route("api/[controller]")]

public class FornecedoresController(IFornecedorService service) : ControllerBase

{
   private readonly IFornecedorService _service = service;

    //public FornecedoresController(IFornecedorService service) => _service = service;


    // GET /api/Cliente
    [HttpGet]
    public IActionResult GetAll()
    {
        var Fornecedor = _service.GetAll();
        return Ok(Fornecedor);
    }

    // GET /api/Cliente/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var Fornecedor = _service.GetById(id);
        if (Fornecedor == null)
            return NotFound();
        return Ok(Fornecedor);
    }

    // POST /api/Fornecedores
    [HttpPost]
    public IActionResult Create([FromBody] Fornecedor Fornecedor)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var criado = _service.Create(Fornecedor);

        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    // PUT /api/Fornecedores/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Fornecedor Fornecedor)
        {
            var atualizado = _service.Update(id, fornecedor: Fornecedor);

            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

    // DELETE /api/Fornecedores/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletado = _service.Delete(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}


