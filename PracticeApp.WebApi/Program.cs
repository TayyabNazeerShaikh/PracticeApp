using PracticeApp.Core.Interfaces;
using PracticeApp.Core.Services;
using PracticeApp.Data.Repositories;
using Scalar.AspNetCore;

namespace PracticeApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // Register services
            builder.Services.AddSingleton<IProductRepository>
            (
                new ProductRepository("Data Source=products.db")
            );
            builder.Services.AddScoped<ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            // Add a middleware to redirect to the desired URL
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("https://localhost:7296/scalar/v1");
                    return;
                }

                await next();
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
