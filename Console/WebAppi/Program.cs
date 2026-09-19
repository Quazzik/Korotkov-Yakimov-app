using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using WebAppi.Sevices;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Console.Services;

namespace WebAppi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mapper = new MapperConfiguration(mc => mc.AddProfile<MapperProfile>())
                .CreateMapper();

            builder.Services.AddSingleton(mapper);

            // Add services to the container.
            builder.Services.AddDbContext<SuperDBContext>(opt => 
                opt.UseNpgsql("User ID=bf;Password=postgres9269;Host=147.45.183.171;Port=15432;Database=bf;"));
            builder.Services.AddTransient<AglomCalcService>();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}
