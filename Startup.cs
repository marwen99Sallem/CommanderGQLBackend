using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;

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
        //Write code to add services to the service container "IServiceProvider" here

        services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
        (Configuration.GetConnectionString("CommandConStr")));

        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddProjections();
        
         }



        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
        //Write code here to configure the request processing pipeline
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

        app.UseGraphQLVoyager("/ui-voyager", new VoyagerOptions()
        {
            GraphQLEndPoint = "/graphql"
        }) ;
       
    }

    }
