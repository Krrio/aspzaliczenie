using Egzamin2023.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IDateProvider, DefaultDateProvider>();
builder.Services.AddSingleton<NoteService>();

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

app.MapControllerRoute(
    name: "createExam",
    pattern: "Exam/Create",
    defaults: new { controller = "Exam", action = "Create" });

app.MapControllerRoute(
    name: "examDetails",
    pattern: "Exam/Details/{title}",
    defaults: new { controller = "Exam", action = "Details" });

app.Run();


public partial class Program
{

}