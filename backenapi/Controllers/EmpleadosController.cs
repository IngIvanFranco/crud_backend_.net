using api.Data.Repositories;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backenapi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosRepository _empleadosRepository;

        public EmpleadosController(IEmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository; 
        }





        [HttpGet]
        public async Task<IActionResult> GetAllEmpleados()
        {
            return Ok(await _empleadosRepository.GetAllEmpleados());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailEmpleado(int id)
        {
            return Ok(await _empleadosRepository.GetEmpleadoDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();

            if (!ModelState.IsValid)    
                return BadRequest();

            var created = await _empleadosRepository.InsertEmpleado(empleado);
            return Created("Created", created);

        }

        [HttpPut]
        public async Task<IActionResult> EditEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

         await _empleadosRepository.UpdateEmpleado(empleado);
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletEmpleado(int id)
        {
            await _empleadosRepository.DeleteEmpleado(new Empleado() { Id = id });
            return NoContent();
        }
    }
}
