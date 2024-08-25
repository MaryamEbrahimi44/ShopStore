using Admin.EndPoint.MappingProfiles;
using Application._services;
using Application.Dto;
using Application.Interfaces;
using Application.Validators;
using FluentValidation;
using Infrastructure.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Contexts.Mongo;

namespace Admin.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<IGetTodayReportService, GetTodayReportService>();
            builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));          
            builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();
            builder.Services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
            builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
            builder.Services.AddTransient<IImageUploadService, ImageUploadService>();
            builder.Services.AddTransient<IBannerService, BannerService>();

            builder.Services.AddScoped<IDatabaseContext , DatabaseContext>();
            string connection = builder.Configuration["ConnectionStrings:SqlServer"];
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
            builder.Services.AddAutoMapper(typeof(CatalogVMMappingProfile));

            //fluentValidation
            builder.Services.AddTransient<IValidator<AddNewCatalogItemDto>, AddNewCatalogItemDtoValidator>();
        

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
