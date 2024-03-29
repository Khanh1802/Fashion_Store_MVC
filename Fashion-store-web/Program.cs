using Fashion_store_web.Options;
using Fashion_store_web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. And add RedLoad
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["FashionStore:EndPoint"]);
});
builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["FashionStore:EndPoint"]);
});
builder.Services.AddHttpClient<ISizeService, SizeService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["FashionStore:EndPoint"]);
});
builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["FashionStore:EndPoint"]);
});

builder.Services.Configure<OptionsCategory>(builder.Configuration.GetSection("FashionStore:Categories"));
builder.Services.Configure<OptionsProduct>(builder.Configuration.GetSection("FashionStore:Products"));
builder.Services.Configure<OptionsSize>(builder.Configuration.GetSection("FashionStore:Sizes"));
builder.Services.Configure<OptionsProductImage>(builder.Configuration.GetSection("FashionStore:ProductImages"));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
