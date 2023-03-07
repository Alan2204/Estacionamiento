using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Estacionamiento
{
   

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;         
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

        }

    }
}
