using Microsoft.AspNetCore.Mvc;

namespace PresencialesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BebidasController : ControllerBase
    {
        private static List<Bebidas> bebidas = new List<Bebidas>();

        [HttpGet]
        public ActionResult<IEnumerable<Bebidas>> GetBebidas(){
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public ActionResult<Bebidas> GetBebida(int id) {
            var bebida = bebidas.FirstOrDefault(p => p.Id == id);
            if ( bebida == null)
            {
                return NotFound();
            }
            return Ok(bebida);
        }

        [HttpPost]
        public ActionResult<Bebidas> CreateBebidas(Bebidas bebida)
        {
            bebidas.Add(bebida);
            return CreatedAtAction(nameof(GetBebida), new { id = bebida.Id}, bebida);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBebida(int id, Bebidas updateBebida)
        {
            var bebida = bebidas.FirstOrDefault(p => p.Id == id);
            if (bebida == null )
            {
                return NotFound();
            }
            bebida.Nombre = updateBebida.Nombre;
            bebida.Precio = updateBebida.Precio;
            bebida.EsDescafeinado = updateBebida.EsDescafeinado;
            return NoContent();
        }

        [HttpDelete("{id}")]
            public IActionResult DeleteBebida(int id)
        {
            var bebida = bebidas.FirstOrDefault(p => p.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }
            bebidas.Remove(bebida);
            return NoContent();
        }

        //Inicializar datos//
        public static void InicializarDatos()
        {
            bebidas.Add(new Bebidas("Té",2.20,true));
        }

    }
}