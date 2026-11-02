using homework10WEB_API.Context;
using homework10WEB_API.Models.Entities;
using homework10WEB_API.Repositories;
using homework10WEB_API.Repositories.Interfaces;
using homework10WEB_API.Services;
using Microsoft.EntityFrameworkCore;

namespace homework10WEB_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // тут змінити на ваш фронтенд
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("def")));

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<UserService>();

            builder.Services.AddTransient<IRepository<Film>, FilmRepository>();
            builder.Services.AddTransient<FilmService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "Really cool cinema web site");
                });
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowSpecificOrigin");
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
