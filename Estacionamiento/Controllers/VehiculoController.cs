using Microsoft.AspNetCore.Mvc;

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
    }
}
