using Estacionamiento.Entidades;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ActionResult<List<Estacionamientos>> get()
        {
            return new List<Estacionamientos>()
            {
                new Estacionamientos() {id=1, Dir="Jorge González Camarena, Sin Nombre de Col 10, 66412 San Nicolás de los Garza, N.L.", EspMax=50, Tarifa=62},
                new Estacionamientos() {id=2, Dir="Av. Sendero Divisorio, Joyas de Anahuac, 66058 Cd Gral Escobedo, N.L.", EspMax=70, Tarifa=30},
                new Estacionamientos() {id=3, Dir="Estacionamiento Cavacitos, Sin Nombre de Col 17, 66052 Cd Gral Escobedo, N.L.", EspMax=45, Tarifa=65},
                new Estacionamientos() {id=4, Dir="Cataluña # 140, Iturbide, 66420 San Nicolás de los Garza, N.L.", EspMax=75, Tarifa = 35}
                

            };
        }
    }
}
