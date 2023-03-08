using Estacionamiento.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace Estacionamiento.Controllers
{
    [ApiController]
    [Route("api/estacionamiento")]
    public class EstacionamientoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EstacionamientoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* [HttpGet]
         public ActionResult<List<Estacionamientos>> get()
         {
             return new List<Estacionamientos>()
             {
                 new Estacionamientos() {id=1, Dir="Jorge González Camarena, Sin Nombre de Col 10, 66412 San Nicolás de los Garza, N.L.", EspMax=50, Tarifa=62},
                 new Estacionamientos() {id=2, Dir="Av. Sendero Divisorio, Joyas de Anahuac, 66058 Cd Gral Escobedo, N.L.", EspMax=70, Tarifa=30},
                 new Estacionamientos() {id=3, Dir="Estacionamiento Cavacitos, Sin Nombre de Col 17, 66052 Cd Gral Escobedo, N.L.", EspMax=45, Tarifa=65},
                 new Estacionamientos() {id=4, Dir="Cataluña # 140, Iturbide, 66420 San Nicolás de los Garza, N.L.", EspMax=75, Tarifa = 35}


             };
         }*/

        [HttpGet]
        public async Task<ActionResult<List<Estacionamientos>>> Get()
        {
            return await dbContext.Estacionamientos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estacionamientos estacionamientos)
        {
            dbContext.Add(estacionamientos);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Estacionamientos estacionamientos, int id)
        {
            if (estacionamientos.id != id)
            {
                return BadRequest("El id del estacionamiento no coincide con el establecido en la url.");
            }
            dbContext.Update(estacionamientos);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {

            var exist = await dbContext.Estacionamientos.AnyAsync(x => x.id == Id);
            if (!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Estacionamientos()
            {
                id = Id
            });

            await dbContext.SaveChangesAsync();
            return Ok();
        }



    }
}
