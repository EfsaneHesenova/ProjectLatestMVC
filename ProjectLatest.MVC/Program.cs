using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectLatest.BL.ExternalService.Abstractions;
using ProjectLatest.BL.ExternalService.Implementations;
using ProjectLatest.BL.Profiles.ExploreItemProfiles;
using ProjectLatest.BL.Services.Abstractions;
using ProjectLatest.BL.Services.Implementations;
using ProjectLatest.Core.Models;
using ProjectLatest.DAL.Contexts;
using ProjectLatest.DAL.Repositories.Abstractions;
using ProjectLatest.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<IExploreItemRepository, ExploreItemRepository>();
builder.Services.AddScoped <IExploreItemService, ExploreItemService > ();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddAutoMapper(typeof(ExploreItemProfile).Assembly);

var app = builder.Build();


app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();




app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
          );








app.Run();
