using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Slots.DAL;
using Slots.DAL.Interfaces;
using Slots.DAL.Repositories;
using Slots.Service.Implementations;
using Slots.Service.Interfaces;

namespace Slots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Users\\venam\\source\\repos\\Slots\\Slots\\App_Data");

            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            
            

            builder.Services.InitializeRepositories();
            builder.Services.InitializeServices();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Drink}/{action=GetDrinks}/{id?}");

            app.Run();
        }
    }
}