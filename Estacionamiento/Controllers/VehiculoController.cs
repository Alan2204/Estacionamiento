using Estacionamiento.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Controllers
{
    [ApiController]
    [Route("api/vehiculo")]
    public class VehiculoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VehiculoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> Get()
        {
            return await dbContext.Vehiculo.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Vehiculo vehiculo)
        {
            dbContext.Add(vehiculo);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Vehiculo vehiculo, int id)
        {
            if (vehiculo.id != id)
            {
                return BadRequest("El id del estacionamiento no coincide con el establecido en la url.");
            }
            dbContext.Update(vehiculo);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {

            var exist = await dbContext.Vehiculo.AnyAsync(x => x.id == Id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Vehiculo()
            {
                id = Id
            });

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
