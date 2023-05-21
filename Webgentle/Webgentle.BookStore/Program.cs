using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation()
    .AddViewOptions(option => option.HtmlHelperOptions.ClientValidationEnabled = true);
#endif

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreContext>();
builder.Services.Configure<IdentityOptions>(config =>
{
    config.Password.RequiredLength = 5;
    // 是否必须包含数字
    config.Password.RequireDigit = false;
    // 必须包含小写字母
    config.Password.RequireLowercase = false;
    // 必须包含大写字母
    config.Password.RequireUppercase = false;
    // 需要密码中的非重复字符数
    config.Password.RequiredUniqueChars = 1;
    // 需要一个非字母数字字符。
    config.Password.RequireNonAlphanumeric = false;
});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
// 认证
app.UseAuthentication();
// 授权
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();