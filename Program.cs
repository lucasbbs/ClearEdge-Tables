using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using group_web_application_security.Data;
using Microsoft.AspNetCore.Identity;
using group_web_application_security.Repository.IRepository;
using group_web_application_security.Repository;
using group_web_application_security.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<group_web_application_securityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("group_web_application_securityContext") ?? throw new InvalidOperationException("Connection string 'group_web_application_securityContext' not found.")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/).AddEntityFrameworkStores<group_web_application_securityContext>().AddDefaultTokenProviders().AddDefaultUI();

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