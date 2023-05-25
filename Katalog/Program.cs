using Autofac.Extensions.DependencyInjection;
using Autofac;
using Katalog.Core.Utilities.IoC;
using Katalog.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Katalog.Business.Abstracts;
using Katalog.Business.Concrete;
using Katalog.Business.DependencyResolvers.Autofac;
using Katalog.Dataaccess.Concrete.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});


builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<Kullanici , IdentityRole>(x => 
{

    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 5;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequireUppercase = false;
    x.User.RequireUniqueEmail = true;
    
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/GirisYap";
    // options.LogoutPath ="/CikisYap";
    options.LoginPath = "/Auth/Login";
    options.Cookie.Name = "auth_cookie";
    options.SlidingExpiration = false;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;

    // options.ReturnUrlParameter = "/Home/Index";
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "GirisYap",
      pattern: "GirisYap",
      defaults: new { controller = "Auth", action = "Login" }
  );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "anasayfa",
        pattern: "anasayfa",
        defaults: new { controller = "Home", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "hakkimizda",
        pattern: "hakkimizda",
        defaults: new { controller = "Home", action = "Hakkimizda" }
    );
     endpoints.MapControllerRoute(
        name: "iletisim",
        pattern: "iletisim",
        defaults: new { controller = "Home", action = "Contact" }
    );
    endpoints.MapControllerRoute(
       name: "Admin/Index",
       pattern: "Admin/Index",
       defaults: new { controller = "Admin", action = "Index" }
   );
    endpoints.MapControllerRoute(
       name: "uruntanimlama",
       pattern: "urutanimlama",
       defaults: new { controller = "Admin", action = "UrunTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "firmatanimlama",
       pattern: "firmatanimlama",
       defaults: new { controller = "Admin", action = "FirmaTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "markatanimlama",
       pattern: "markatanimlama",
       defaults: new { controller = "Admin", action = "MarkaTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "tiptanimlama",
       pattern: "tiptanimlama",
       defaults: new { controller = "Admin", action = "TipTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "modeltanimlama",
       pattern: "modeltanimlama",
       defaults: new { controller = "Admin", action = "ModelTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "oemtanimlama",
       pattern: "oemtanimlama",
       defaults: new { controller = "Admin", action = "OEMTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "referanstanimlama",
       pattern: "referanstanimlama",
       defaults: new { controller = "Admin", action = "ReferansTanimlama" }
   );
    endpoints.MapControllerRoute(
       name: "katalogliste",
       pattern: "katalogliste ",
       defaults: new { controller = "Katalog", action = "KatalogListe" }
   );
    endpoints.MapControllerRoute(
       name: "UrunDetay",
       pattern: "UrunDetay",
       defaults: new { controller = "Katalog", action = "UrunDetay" }
   );
   endpoints.MapControllerRoute(
       name: "edit",
       pattern: "admin/edit/{id?}",
       defaults: new { controller = "Admin", action = "Edit" }
   );
   



});

app.Run();
