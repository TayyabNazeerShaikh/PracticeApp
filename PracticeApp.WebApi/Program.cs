using PracticeApp.Core.Interfaces;
using PracticeApp.Core.Services;
using PracticeApp.Data.Repositories;
using PracticeApp.WebApi.Middlewares;
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

            // Register IExceptionHandler implementations.
            builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
            builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            // Generate Problem Details response for common exceptions.
            builder.Services.AddProblemDetails();

            // Register services.
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

            // Add a middleware to redirect to the desired URL.
            app.Use(async (context, next) =>
            {
                // Check if the current request path is the root
                if (context.Request.Path == "/")
                {
                    // Get the current request's scheme (http or https) and host (e.g., localhost:5191)
                    var currentScheme = context.Request.Scheme;     // This will be either "http" or "https"
                    var currentHost = context.Request.Host;         // This will be the host (e.g., localhost:5191)

                    // Construct the redirection URL based on the current request's scheme and host
                    var redirectUrl = $"{currentScheme}://{currentHost}/scalar/v1";

                    // Perform the redirect
                    context.Response.Redirect(redirectUrl);
                    return;
                }

                await next();
            });

            app.UseExceptionHandler();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}