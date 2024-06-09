using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;
using WorkersTurnScheduler.Services;

namespace WorkersTurnScheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorPagesOptions(options => {
                String[] actions = ["Index", "Edit"];
                var basePath = "/SchedulerArea/Workers/Contract";
                var pathTemplate = "SchedulerArea/Workers/{workerId:int}/Contract";
                foreach (var action in actions)
                {
                    var route = $"{pathTemplate}/{action}";

                    if (action != "Index")
                        route += "/{contractId:int}";
                    options.Conventions.AddPageRoute($"{basePath}/{action}", route);
                }
            });

            builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
