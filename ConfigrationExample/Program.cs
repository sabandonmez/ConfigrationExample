
using ConfigrationExample.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("hilmi.json");

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Configration 
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//...
//ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
//IWebHostEnvironment environment = builder.Environment;
#endregion

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<MailInfo>(configuration.GetSection("MailInfo"));

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
