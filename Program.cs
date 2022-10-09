using CommanderGQL;

var builder = WebApplication.CreateBuilder(args);

// this is where the dependency injection registration is accomplished (instead of startup.cs file in previous versions)


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();


startup.Configure(app,builder.Environment);

//app.MapGet("/", () => "Hello World!");

app.Run();
