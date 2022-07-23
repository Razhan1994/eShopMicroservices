using Catalog.API.Common;
using Sentry.Extensibility;

namespace Catalog.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureService(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<DatabaseSettingOptions>(_configuration.GetSection("DatabaseSettings"));

            // Register as many ISentryEventExceptionProcessor as you need. They ALL get called.
            services.AddSingleton<ISentryEventExceptionProcessor, SpecialExceptionProcessor>();

            // You can also register as many ISentryEventProcessor as you need.
            services.AddTransient<ISentryEventProcessor, ExampleEventProcessor>();

            services.AddSentryTunneling();
            // Add services to the container.

            // To demonstrate taking a request-aware service into the event processor above
            services.AddHttpContextAccessor();
        }

        public void configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSentryTracing();

            app.UseSentryTunneling();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
