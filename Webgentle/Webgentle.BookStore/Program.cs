var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
app.Run();
