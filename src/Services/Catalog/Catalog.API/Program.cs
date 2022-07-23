using System.Net;
using Catalog.API;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseSentry();

var startup = new Startup(builder.Configuration);
startup.ConfigureService(builder.Services);

var app = builder.Build();

app.UseSentryTracing();

startup.configure(app);