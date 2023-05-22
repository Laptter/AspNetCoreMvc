using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Helpers;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;
using Webgentle.BookStore.Services;

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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreContext>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

builder.Services.Configure<IdentityOptions>(config =>
{
    config.Password.RequiredLength = 5;
    // �Ƿ�����������
    config.Password.RequireDigit = false;
    // �������Сд��ĸ
    config.Password.RequireLowercase = false;
    // ���������д��ĸ
    config.Password.RequireUppercase = false;
    // ��Ҫ�����еķ��ظ��ַ���
    config.Password.RequiredUniqueChars = 1;
    // ��Ҫһ������ĸ�����ַ���
    config.Password.RequireNonAlphanumeric = false;
    // ����������
    config.Lockout.MaxFailedAccessAttempts = 3;
    // �������3�κ�����ʱ��
    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // Ҫ��������֤
    config.SignIn.RequireConfirmedEmail = true;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/account/login";
});

// set identity token expired time
builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(2));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
// ��֤
app.UseAuthentication();
// ��Ȩ
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();