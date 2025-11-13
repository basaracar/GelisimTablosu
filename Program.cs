using Microsoft.EntityFrameworkCore;
using GelisimTablosu.Models;

var builder = WebApplication.CreateBuilder(args);
// Manuel olarak mutlak yol belirt
//builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();

// Add services to the container.
builder.Services.AddControllersWithViews();

// SQLite bağlantısı ekleniyor
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=App.db"));

var app = builder.Build();
// // Veritabanı işlemleri
using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    await context.SeedKategori();
    await context.SeedKonu();
    await context.SeedStudent();
    //     await context.SeedClasses();
    //     await context.SeedTimeSlots();
    //     await context.SeedAdminUser(userManager);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EgitimYili}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
