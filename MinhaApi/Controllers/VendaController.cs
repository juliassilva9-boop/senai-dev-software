using MinhaApi.Models;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Services;


[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
   private readonly IVendaService _service;

    public VendaController(IVendaService service) => _service = service;

    

    // GET /api/Cliente
    [HttpGet]
    public IActionResult GetAll()
    {
        var Venda = _service.GetAll();
        return Ok(Venda);
    }

    // GET /api/Cliente/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var Venda = _service.GetById(id);
        if (Venda == null)
            return NotFound();
        return Ok(Venda);
    }

    // POST /api/Cliente
    [HttpPost]
    public IActionResult Create([FromBody] Venda Venda)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var criado = _service.Create(Venda);

        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    // PUT /api/Cliente/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Venda Venda)
        {
            var atualizado = _service.Update(id, Venda);

            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

    // DELETE /api/Cliente/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletado = _service.Delete(id);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}
