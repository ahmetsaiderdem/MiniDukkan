using Microsoft.EntityFrameworkCore;
using MiniDukkan.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MiniDukkanContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:MiniDukkanConnection"]));
builder.Services.AddScoped<IDukkanRepository,EFDukkanRepository>();

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

app.UseRouting();
app.UseStatusCodePages();

app.UseAuthorization();

app.MapControllerRoute("sayfalama", "Urunler/Sayfa{urunSayfa}",
    new { controller = "Home", action = "Index" });
app.MapDefaultControllerRoute();

    
HamVeri.VeriDoldur(app);

app.Run();
