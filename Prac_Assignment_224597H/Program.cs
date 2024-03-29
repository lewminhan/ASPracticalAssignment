using Microsoft.AspNetCore.Identity;
using Prac_Assignment_224597H.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AuthDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.Lockout.AllowedForNewUsers = true;
	options.Lockout.MaxFailedAccessAttempts = 3;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}).AddEntityFrameworkStores<AuthDbContext>();
builder.Services.AddDataProtection();

builder.Services.ConfigureApplicationCookie(Config =>
{
	Config.LoginPath = "/Login";
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

app.UseStatusCodePagesWithRedirects("/errors/{0}");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
