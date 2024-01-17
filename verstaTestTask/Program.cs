

using Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using StepMaster.Initialization.Scope;
using verstaTestTask.Initialization.InitialDataBase;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
services.AddControllersWithViews();
InitialDb.StatrtDb(builder);
ScopeBuilder.InitializerService(services);
ScopeBuilder.InitializerRepsitories(services);

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
