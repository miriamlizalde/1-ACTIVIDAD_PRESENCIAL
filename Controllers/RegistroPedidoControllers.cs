using Microsoft.AspNetCore.Mvc;
using Models;


namespace PresencialesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPedidoControllers : ControllerBase
    {
        private static List<RegistroPedido> registro = new List<RegistroPedido>();

        [HttpGet]
        public ActionResult<IEnumerable<RegistroPedido>> GetRegistro()
        {
            return Ok(registro);
        }

        [HttpGet("{id}")]
        public ActionResult<RegistroPedido> GetRegistro(int id)
        {
            var RegistroPedido = registro.FirstOrDefault(p => p.Id == id);
            if (RegistroPedido == null)
            {
                return NotFound();
            }
            return Ok(RegistroPedido);
        }

        [HttpPost]
        public ActionResult<RegistroPedido> CreateRegistro(RegistroPedido pedido)
        {
            registro.Add(pedido);
            return CreatedAtAction(nameof(GetRegistro), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, RegistroPedido updatedRegistro)
        {
            var pedido = registro.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            pedido.Nombre = updatedRegistro.Nombre;
            pedido.Precio = updatedRegistro.Precio;
            pedido.Registro = updatedRegistro.Registro;
            pedido.Pagado = updatedRegistro.Pagado;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegistro(int id)
        {
            var pedido = registro.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            registro.Remove(pedido);
            return NoContent();
        }

        // Método para inicializar datos
        public static void InicializarDatos()
        {
            registro.Add(new RegistroPedido("sandwich", 12.50));
            registro.Add(new RegistroPedido("muffing", 10.00));
        }

    }
}