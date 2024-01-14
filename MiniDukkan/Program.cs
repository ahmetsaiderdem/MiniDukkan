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

app.MapControllerRoute("katsayfa", "{kategori}/Sayfa{urunSayfa:int}", 
    new  { Controller = "Home", action = "Index" });
app.MapControllerRoute("sayfa", "Sayfa{urunSayfa:int}", 
    new { Controller = "Home", action = "Index" ,urunSayfa=1});

app.MapControllerRoute("kategori", "{kategori}",
    new { Controller = "Home", action = "Index", urunSayfa = 1 });

app.MapControllerRoute("sayfalama", "Urunler/Sayfa{urunSayfa}",
    new { controller = "Home", action = "Index", urunSayfa = 1 });
app.MapDefaultControllerRoute();

    
HamVeri.VeriDoldur(app);

app.Run();
