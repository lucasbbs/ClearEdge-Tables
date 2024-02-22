using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClearEdge_Tables.Data;
using Microsoft.AspNetCore.Identity;
using ClearEdge_Tables.Repository.IRepository;
using ClearEdge_Tables.Repository;
using ClearEdge_Tables.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClearEdge_TablesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClearEdge_TablesContext") ?? throw new InvalidOperationException("Connection string 'ClearEdge_TablesContext' not found.")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/).AddEntityFrameworkStores<ClearEdge_TablesContext>().AddDefaultTokenProviders().AddDefaultUI();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();