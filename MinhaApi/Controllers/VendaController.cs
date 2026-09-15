using MinhaApi.Models;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Services;


[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
   private readonly IVendaService _service;

    public VendaController(IVendaService service) => _service = service;

    

    // GET /api/Cliente/1
    // [HttpGet("{id}")]
    // public IActionResult GetById(int id)
    // {
    //     var Venda = _service.GetById(id);
    //     if (Venda == null)
    //         return NotFound();
    //     return Ok(Venda);
    // }

    // POST /api/Cliente
    [HttpPost]
    public IActionResult Create([FromBody] Venda Venda)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var criado = _service.Create(Venda);

        return Ok(criado);
    }


} 
