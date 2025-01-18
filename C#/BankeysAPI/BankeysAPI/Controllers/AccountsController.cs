using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/clientes
    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _context.Clientes.ToListAsync();
        return Ok(clientes);
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
    {
        if (cliente == null)
        {
            return BadRequest("Cliente não pode ser nulo");
        }

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        // Retorna a URL para acessar o recurso recém-criado
        return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
    }
}