using BTL.Models;
using BTL.repository;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight,
    PreventDuplicates = true,
    TimeOut = 3000,
    CloseButton = true
}).AddRazorRuntimeCompilation();
var connectionString = builder.Configuration.GetConnectionString("QuanLyGiaoTrinhContext");
builder.Services.AddDbContext<QuanLyGiaoTrinhContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<ILoaiSprepository, LoaiSprepository>();


builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
