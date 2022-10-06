using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL;

    public class Startup
    {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
        {
           Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
         {

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer
        (Configuration.GetConnectionString("CommandConStr")));

         }



        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseWebSockets();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });

       
    }

    }
