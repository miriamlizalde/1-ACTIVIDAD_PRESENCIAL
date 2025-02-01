using Microsoft.AspNetCore.Mvc;

namespace PresencialesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComidaControllers : ControllerBase
    {
        private static List<Comida> comidas = new List<Comida>();

        [HttpGet]
        public ActionResult<IEnumerable<Comida>> GetComidas(){
            return Ok(comidas);
        }

        [HttpGet("{id}")]
        public ActionResult<Comida> GetComidas(int id) {
            var comida = comidas.FirstOrDefault(p => p.Id == id);
            if ( comida == null)
            {
                return NotFound();
            }
            return Ok(comida);
        }

        [HttpPost]
        public ActionResult<Comida> CreateComidas(Comida comida)
        {
            comidas.Add(comida);
            return CreatedAtAction(nameof(GetComidas), new { id = comida.Id}, comida);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComida(int id, Comida updateComida)
        {
            var comida = comidas.FirstOrDefault(p => p.Id == id);
            if (comida == null )
            {
                return NotFound();
            }
            comida.Nombre = updateComida.Nombre;
            comida.Precio = updateComida.Precio;
            comida.ConGluten = updateComida.ConGluten;
            comida.Ingredientes = updateComida.Ingredientes;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
            public IActionResult DeleteComida(int id)
        {
            var comida = comidas.FirstOrDefault(p => p.Id == id);
            if (comida == null)
            {
                return NotFound();
            }
            comidas.Remove(comida);
            return NoContent();
        }

        //Inicializar datos//
        public static void InicializarDatos()
        {
            comidas.Add(new Comida("Sandwich",3.50,false,"pan de sesamo" ));
            comidas.Add(new Comida("Croissant", 2.00,true,"con chocolate"));
            comidas.Add(new Comida("Tostada", 2.50,true,"con aceite"));
            comidas.Add(new Comida("Napolitana", 1.80,false,"de crema"));
            comidas.Add(new Comida("Palmera", 2.10,false,"de coco"));
            comidas.Add(new Comida("Muffing", 1.30, true,"con birutas de chocolate"));
        }
    

    }
}