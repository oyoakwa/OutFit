using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OutFit.Plugin.Database;
using OutFit.UseCases.Carts;
using OutFit.UseCases.Carts.Interfaces;
using OutFit.UseCases.PluginInterfaces;
using OutFit.UseCases.Products;
using OutFit.UseCases.Products.Interfaces;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OutFit.CoreBusiness.Data;
using OutFit.CoreBusiness;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OutFit.Web;
using System.Security.Claims;
using OutFit.UseCases.Orders.Interfaces;
using OutFit.UseCases.Orders;
using OutFit.UseCases.ProductOrder.Interfaces;
using OutFit.UseCases.ProductOrder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<WebsiteAuthenticator>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebsiteAuthenticator>());
builder.Services.TryAddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IProductOrderRepository, ProductOrderRepository>();
builder.Services.TryAddTransient<ICartRepository,CartRepository>();   
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IAddToCartUseCase,AddToCartUseCase>();
builder.Services.AddTransient<IViewCartUseCase, ViewCartUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
builder.Services.AddTransient<IMakeOrderUseCase, MakeOrderUseCase>();
builder.Services.AddTransient<IAddProductOrderUseCase, AddProductOrderUseCase>();



builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ ";
    options.SignIn.RequireConfirmedEmail = false;

}).AddEntityFrameworkStores<OutFitDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
builder.Services.AddDbContext<OutFit.CoreBusiness.Data.OutFitDbContext>(options =>
{
    var configuration = builder.Configuration;
    var connectionString = configuration.GetConnectionString("OutFit");
    options.UseNpgsql(connectionString);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/account";
    options.AccessDeniedPath = "/account";
    options.SlidingExpiration = true;
});

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
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.UseDeveloperExceptionPage();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
