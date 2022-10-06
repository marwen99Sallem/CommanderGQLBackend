var builder = WebApplication.CreateBuilder(args);

// this is where the dependency injection registration is accomplished (instead of startup.cs file in previous versions)



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
