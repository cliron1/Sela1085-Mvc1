using FirstMvc.Services;

WebApplicationBuilder builder;

builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IUsersService, UsersService>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// http://aa.com/users/edit/5
// https://aa.com/users/edit/5
app.UseHttpsRedirection(); // => Short circuit

// http://aa.com/css/site.css
// http://aa.com/imgs/logo.png
app.UseStaticFiles(); // logo.png | script.js | site.css  || => Short circuit

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();