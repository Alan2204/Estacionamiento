using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Controllers
{
    [ApiController]
    public class IngresoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public IngresoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
