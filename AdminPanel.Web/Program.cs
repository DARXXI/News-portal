using AdminPanel.Domain.Entities;
using AdminPanel.Repository;
using AdminPanel.Repository.Repositories;
using AdminPanel.Repository.Repositories.Interfaces;
using AdminPanel.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Web.hubs;
using AdminPanel.TelegramBot;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProjectRepository, UserProjectRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddTransient<IChatRepository<Message>, ChatRepository>();

//TODO
TelegramBot telegramBot = new();
telegramBot.RunAsync();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/account/login";
        options.AccessDeniedPath = "/accessdenied";
    });



var app = builder.Build();

//app.UseCors(builder =>
//{
//    builder.WithOrigins("http://localhost:5000/chat")
//        .AllowAnyHeader()
//        .WithMethods("GET", "POST")
//        .AllowCredentials();
//});

app.UseDefaultFiles();
app.UseStaticFiles();


//var options = new RewriteOptions().AddRewrite("~/account/(.*)", "/", skipRemainingRules: false); ;
//app.UseRewriter(options);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The defaultHSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapHub<ChatHub>("/chat");


app.UseRouting();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
