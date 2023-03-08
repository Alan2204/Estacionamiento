using Estacionamiento.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estacionamiento.Controllers
{
    [ApiController]
    [Route("api/Lugar")]

    public class LugarController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LugarController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> Get()
        {
            return await dbContext.Lugar.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Lugar lugar)
        {
            dbContext.Add(lugar);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        /*[HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Lugar lugar, int id)
        {
            if (lugar.id != id)
            {
                return BadRequest("El id del estacionamiento no coincide con el establecido en la url.");
            }
            dbContext.Update(lugar);
            await dbContext.SaveChangesAsync();
            return Ok();
        }*/

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {

            var exist = await dbContext.Estacionamientos.AnyAsync(x => x.id == Id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Lugar()
            {
                id = Id
            });

            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
