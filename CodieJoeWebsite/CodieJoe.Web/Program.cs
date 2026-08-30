using CodieJoe.Web.Data.Utility;
using CodieJoe.Web.Extentions.Data;
using CodieJoe.Web.Extentions.Identity;
using CodieJoe.Web.Extentions.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddIdentityConfiguration();
builder.Services.ConfigureWebApplication();
builder.Services.AddRepositoryLifetime();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();
app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();


app.Run();