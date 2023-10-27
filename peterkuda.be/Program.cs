using Microsoft.AspNetCore.HttpOverrides;
using CurriculumVitae.Services;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
); // For use behind a reverse proxy server
builder.Services.AddTransient<ICvService, InternalCvService>();

//Translations
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supporteCultures = new List<CultureInfo> {
        new CultureInfo("nl-BE"),
        new CultureInfo("nl"),
        new CultureInfo("fr-BE"),
        new CultureInfo("fr"),
        new CultureInfo("en")
    };
}
);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseForwardedHeaders(); // for use behind a reverse proxy server
    app.UseHsts(); // Enforce SSL
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
