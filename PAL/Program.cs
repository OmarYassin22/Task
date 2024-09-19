using BL.Interfaces;
using PAL.Services;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using PAL.Helper;
using BL.ApplicationRepo;

namespace PAL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICountryValidService, CountryValiedService>();
            builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            builder.Services.AddAutoMapper(m => m.AddProfile(new MapperProfiler()));
            builder.Services.AddHttpClient();

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Applicant}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
