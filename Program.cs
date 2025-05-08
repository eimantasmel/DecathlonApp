using DecathlonApp.Services;
using DecathlonApp.Services.InputParsers;
using DecathlonApp.Services.Interfaces;
using DecathlonApp.Services.OutputFormatters;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Decathlon services
builder.Services.AddSingleton<DecathlonCalculator>();
builder.Services.AddSingleton<IResultProcessor, ResultProcessor>();
builder.Services.AddSingleton<IInputParser, CsvInputParser>();
builder.Services.AddSingleton<IOutputFormatter, JsonOutputFormatter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Decathlon/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Decathlon}/{action=Index}/{id?}");

app.Run();