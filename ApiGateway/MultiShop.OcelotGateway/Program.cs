using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
builder.Services.AddOcelot(configuration);

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "ResourceOcelot";
        options.RequireHttpsMetadata = false;

    });


var app = builder.Build();
await app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();
