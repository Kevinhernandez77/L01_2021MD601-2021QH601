using L01_2021MD601_2021QH601.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace L01_2021MD601_2021QH601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class platosController : ControllerBase
    {
        private readonly restauranteDBContext _restauranteBDContexto;

        public PlatosController(restauranteDBContext restauranteBDContexto)
        {
            _restauranteBDContexto = restauranteBDContexto;
        }

        [HttpGet]
        [Route("GetALL")]
        public IActionResult Get()
        {
            List<platos> listadoplatos = (from e in _restauranteBDContexto.platos select e).ToList();

            if (listadoplatos.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoplatos);


        }





        [HttpGet]
        [Route("GetById/(id)")]
        public IActionResult Get(int id)
        {
            platos? platos = (from e in _restauranteBDContexto.platos where e.platoId == id select e).FirstOrDefault();

            if (platos == null)
            {
                return NotFound();
            }
            return Ok(platos);


        }






        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarEquipo([FromBody] platos platos)
        {
            try
            {
                _restauranteBDContexto.platos.Add(platos);
                _restauranteBDContexto.SaveChanges();
                return Ok(platos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }







        [HttpPut]
        [Route("Actualizar/(id)")]
        public IActionResult ActualizarEquipo(int id, [FromBody] platos platosModificadar)
        {
            platos? platosActual = (from e in _restauranteBDContexto.platos
                                    where e.platoId == id
                                    select e).FirstOrDefault();

            if (platosActual == null)
            {
                return NotFound();
            }

            platosActual.platoId = platosModificadar.platoId;
            platosActual.nombrePlato = platosModificadar.nombrePlato;
            platosActual.precio = platosModificadar.precio;



            _restauranteBDContexto.Entry(platosActual).State = EntityState.Modified;
            _restauranteBDContexto.SaveChanges();
            return Ok(platosModificadar);

        }










        [HttpDelete]
        [Route("Eliminar/(id)")]
        public IActionResult EliminarEquipo(int id)
        {
            platos? equipo = (from e in _restauranteBDContexto.platos
                              where e.platoId == id
                              select e).FirstOrDefault();

            if (equipo == null)
                return NotFound();

            _restauranteBDContexto.platos.Attach(equipo);
            _restauranteBDContexto.platos.Remove(equipo);
            _restauranteBDContexto.SaveChanges();

            return Ok(equipo);




        }
    }
}
