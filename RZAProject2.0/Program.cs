using Microsoft.EntityFrameworkCore;
using RZAProject2._0.Components;
using RZAProject2.Models;
using RZAProject2.Services;
using RZAProject2.Utilities;
namespace RZAProject2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<TlS2302452RzaContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
            new MySqlServerVersion(new Version(8, 0, 29))));

            builder.Services.AddScoped<CustomerService>();


            builder.Services.AddSingleton<UserSession>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
