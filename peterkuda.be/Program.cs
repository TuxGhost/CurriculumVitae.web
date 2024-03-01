using Microsoft.AspNetCore.HttpOverrides;
using CurriculumVitae.Services;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using CurriculumVitae.Data;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<CurriculumVitaeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
); // For use behind a reverse proxy server
// determin if static or database service should be used.
bool? databaseService = builder.Configuration.GetValue<bool>("DatabaseService");
if (databaseService == true)
{
    //builder.Services.AddTransient<ICvService, SQLiteCvService>();
    builder.Services.AddScoped<ICvService,SQLiteCvService>();
} else
    builder.Services.AddTransient<ICvService, InternalCvService>();

builder.Services.AddTransient<IEmailSender, EmailSender>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var r1 = applicationDbContext.Database.EnsureCreated();
    var cvDbContext = scope.ServiceProvider.GetRequiredService<CurriculumVitaeDbContext>();
    var r2 = cvDbContext.Database.EnsureCreated();
    cvDbContext.Database.Migrate();
}

app.Run();
