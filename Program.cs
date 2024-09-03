
using Labb1_ASP.NET_API.Data;
using Labb1_ASP.NET_API.Models.DTOs.Booking;
using Labb1_ASP.NET_API.Repositories;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Labb1_ASP.NET_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Configuration.AddEnvironmentVariables();
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext"));
            });

            //Changeing format of datetime in swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<DateTimeSchemaFilter>();
            });
            //Changeing format of datetime in swagger
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new CustomDate());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();
            builder.Services.AddScoped<ITableService, TableService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
