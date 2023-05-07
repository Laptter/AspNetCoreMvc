var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.Run();
