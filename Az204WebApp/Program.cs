using BusinessLogic.CQRS.GetConfigItem;
using Microsoft.Extensions.FileProviders;

namespace Az204WebApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseFileServer();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services
                .AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(GetConfigItemQuery)));
        }
    }
}