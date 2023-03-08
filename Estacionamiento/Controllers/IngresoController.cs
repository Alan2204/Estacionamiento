using Estacionamiento.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Controllers
{
    [ApiController]
    [Route("api/Ingreso")]
    public class IngresoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public IngresoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingreso>>> GetAll()
        {
            return await dbContext.Ingreso.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ingreso>> GetById(int Id)
        {
            return await dbContext.Ingreso.FirstOrDefaultAsync(x => x.id == Id);
        }

       [HttpPost]
        public async Task<ActionResult> Post(Ingreso ingreso)
        {
            var existeVehiculo =  await dbContext.Vehiculo.AnyAsync(x => x.id == ingreso.idVehiculo);
            var existeEstacionamiento = await dbContext.Estacionamientos.AnyAsync(x => x.id == ingreso.idEstacionamientos);

            if (!existeVehiculo)
            {
                return BadRequest($"No existe el vehiculo con el id: {ingreso.idVehiculo} ");
            }

            if (!existeEstacionamiento)
            {
                return BadRequest($"No existe el estacionamiento con el id: {ingreso.idEstacionamientos} ");
            }

            dbContext.Add(ingreso);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Ingreso ingreso, int Id)
        {
            var existe = await dbContext.Ingreso.AnyAsync(x => x.id == Id);

            if (!existe)
            {
                return BadRequest("El elemento buscado no existe. ");
            }

            if (ingreso.id != Id)
            {
                return BadRequest("El id del ingreso no coincide con el establecido en la url.");
            }
            dbContext.Update(ingreso);
            await dbContext.SaveChangesAsync();
            return Ok();


        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await dbContext.Ingreso.AnyAsync(x => x.id == Id);

            if (!existe)
            {
                return NotFound();
            }

            dbContext.Remove(new Ingreso { id = Id});
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
