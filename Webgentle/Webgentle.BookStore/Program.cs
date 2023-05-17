using Microsoft.EntityFrameworkCore;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif


builder.Services.AddScoped<LanguageRepository>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
