using FirstMvc.Data;
using FirstMvc.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsersService, UsersServiceDb>(); // << downgrade to Scoped

builder.Services.AddDbContext<MyContext>(options =>
     options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Gallery_1085;Trusted_Connection=True;")
);







var app = builder.Build();

await using(var scope = app.Services.CreateAsyncScope()) {
	using var context = scope.ServiceProvider.GetService<MyContext>();
	await context.Database.MigrateAsync();
	//await context.Database.EnsureCreatedAsync();
}

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

app.UseStaticFiles(new StaticFileOptions() {
    RequestPath = "/utils",
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "node_modules"))
});

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
