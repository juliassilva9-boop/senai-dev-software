using MinhaApi.Models;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Services;


[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
   private readonly IClienteService _service;

    public ClienteController(IClienteService service) => _service = service;

    

    // GET /api/Cliente
    [HttpGet]
    public IActionResult GetAll()
    {
        var Clientes = _service.GetAll();
        return Ok(Clientes);
    }

    // GET /api/Cliente/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var Cliente = _service.GetById(id);
        if (Cliente == null)
            return NotFound();
        return Ok(Cliente);
    }

    // POST /api/Cliente
    [HttpPost]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var criado = _service.Create(cliente);

        return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
    }

    // PUT /api/Cliente/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Cliente Cliente)
        {
            var atualizado = _service.Update(id, Cliente);

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
