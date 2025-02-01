using Microsoft.AspNetCore.Mvc;

namespace PresencialesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesControllers : ControllerBase
    {
        public static List<Clientes> clientes = new List<Clientes>();

        [HttpGet]
        public ActionResult<IEnumerable<Clientes>> GetClientes(){
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Clientes> GetClientes(int id) {
            var cliente = clientes.FirstOrDefault(p => p.Id == id);
            if ( cliente == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        [HttpPost]
        public ActionResult<Clientes> CreateClientes(Clientes cliente)
        {
            clientes.Add(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id}, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, Clientes updateCliente)
        {
            var cliente = clientes.FirstOrDefault(p => p.Id == id);
            if (cliente == null )
            {
                return NotFound();
            }
            cliente.Nombre = updateCliente.Nombre;
            cliente.Telefono = updateCliente.Telefono;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
            public IActionResult DeleteCliente(int id)
        {
            var cliente = clientes.FirstOrDefault(p => p.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            clientes.Remove(cliente);
            return NoContent();
        }

        //Inicializar datos//
        public static void InicializarDatos()
        {
            clientes.Add(new Clientes("Juan", "976584752"));
            clientes.Add(new Clientes("Maria","654789158"));
            clientes.Add(new Clientes("Pedro","621486325"));
            clientes.Add(new Clientes("Miriam","678455122"));
            clientes.Add(new Clientes("Frank","975412589"));
            clientes.Add(new Clientes("Laura","976334577"));
        }
    

    }
}