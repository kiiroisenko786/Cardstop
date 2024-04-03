using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository;
using Cardstop.DataAccess.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Cardstop.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;
using Cardstop.DataAccess.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddAuthentication().AddFacebook(option =>
{
    option.AppId = "1801970256979503";
    option.AppSecret = "58cf05b4bfb43eb5e28e20c124f1f45e";
});

builder.Services.AddAuthentication().AddMicrosoftAccount(option =>
{
    option.ClientId = "5e91bc89-dd53-434a-b90f-6d9cdb09067b";
    option.ClientSecret = "aaV8Q~jbDE9IvQxnrD7e9wmCb262iJ.iEuFXIai2";
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<iDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<iUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<iDbInitializer>();
        dbInitializer.Initialize();
    }
}