using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TDDPOC.Core.DataServices;
using TDDPOC.Core.Processors;
using TDDPOC.Persistence;
using TDDPOC.Persistence.Repositories;

namespace TDDPOC.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RoomBookingApp.Api", Version = "v1" });
            });

            var connString = "DefaultConnection";
            var conn = new SqlConnection(connString);
            conn.Open();

            services.AddDbContext<RoomBookingAppDbContext>(opt => 
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRoomBookingService, RoomBookingService>();
            services.AddScoped<IRoomBookingRequestProcessor, RoomBookingRequestProcessor>();
        }

        private static void EnsureDatabaseCreated(SqliteConnection conn)
        {
            var builder = new DbContextOptionsBuilder<RoomBookingAppDbContext>();
            builder.UseSqlServer(conn);

            using var context = new RoomBookingAppDbContext(builder.Options);
            context.Database.EnsureCreated();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoomBookingApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
