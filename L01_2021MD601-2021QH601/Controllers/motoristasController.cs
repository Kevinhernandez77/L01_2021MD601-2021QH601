using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace L01_2021MD601_2021QH601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristasController : ControllerBase
    {
        private readonly restauranteDBContext _restauranteDBContext;
        public motoristasController(restauranteDBContext restauranteDBContext)
        {
            _restauranteDBContext = restauranteDBContext;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get(
        {
            List<motoristas> listadoMotorista = (from e in _restauranteDBContext.motoristas
                                                 select e).ToList();

            if (listadoMotorista.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoMotorista);
        }


    }
}