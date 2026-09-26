using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DepartamentoController(IDepartamentoService service) : ControllerBase
{
    private readonly IDepartamentoService _service = service;

    // GET /api/Departamento

    [HttpGet]
    public IActionResult GetAll()
    {
        var Departamento = _service.GetAll();
        return Ok(Departamento);
    }

    // GET /api/Departamento/1
    [HttpGet("{id_Departamento}")]
    public IActionResult GetById(int id_Departamento)
    {
        var Departamento = _service.GetById(id_Departamento);
        if (Departamento == null)
            return NotFound();
        return Ok(Departamento);
    }

    // POST /api/Departamento
    [HttpPost]
    public IActionResult Create([FromBody] Departamento Departamento)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var criado = _service.Create(Departamento);

        return CreatedAtAction(nameof(GetById), new { id_Departamento = criado.id_departamento }, criado);
    }

    // PUT /api/produto/1
    [HttpPut("{id_Departamento}")]
    public IActionResult Update(int id_Departamento, [FromBody] Departamento Departamento)
        {
            var atualizado = _service.Update(id_Departamento);

            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

    // DELETE /api/produto/1
    [HttpDelete("{id_Departamento}")]
    public IActionResult Delete(int id_Departamento)
    {
        var deletado = _service.Delete(id_Departamento);

        if (!deletado)
            return NotFound();

        return NoContent();
    }
}