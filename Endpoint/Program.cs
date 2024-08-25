using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Infrastructure.IdentityConfigs;
using Application.Interfaces;
using Application.Visitor;
using Persistence.Contexts.Mongo;
using Website.Endpoint2.Utilitis.Filters;
using Endpoint.Hubs;
using Application._services;
using Endpoint.Utilitis.MiddleWares;
using Infrastructure.MappingProfile;

namespace Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();
            builder.Services.AddTransient<IIdentityDatabaseContext, IdentityDatabaseContext>();

            string connection = builder.Configuration["ConnectionStrings:SqlServer"];

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            builder.Services.AddIdentityService(builder.Configuration);
            builder.Services.AddAuthorization();
            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.LoginPath = "/Account/login";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                option.SlidingExpiration=true;

            });
            builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
            builder.Services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
            builder.Services.AddTransient<IGetMenueItemService, GetMenueItemService>();
            builder.Services.AddTransient<IUriComposerService, UriComposerService>();
            builder.Services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
            builder.Services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
            builder.Services.AddTransient<IBasketService, BasketService>();
            builder.Services.AddTransient<IUserAddressService, UserAddressService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();

            builder.Services.AddTransient<ICustomerOrderService, CustomerOrderService>();
            builder.Services.AddTransient<IHomePageService, HomePageService>();

            builder.Services.AddScoped<SaveVisitorFilter>();
            builder.Services.AddSignalR();
            builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
            builder.Services.AddAutoMapper(typeof(UserMappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSetVisitorId();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => 
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<OnlineVisitorsHub>("/chathub");
               
         

            });
            
          

            app.Run();
        }
    }
}
