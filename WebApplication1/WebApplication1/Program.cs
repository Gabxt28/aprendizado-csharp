using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();  

// 🔐 Configuração do Cookie de Autenticação
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login"; // Redireciona para /Login quando não autenticado
    options.AccessDeniedPath = "/AccessDenied"; // Página para acesso negado
    options.LogoutPath = "/Logout"; // Página de logout
    options.ExpireTimeSpan = TimeSpan.FromDays(7); // Cookie expira em 7 dias
    options.SlidingExpiration = true; // Renova o cookie automaticamente
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANTE: UseAuthentication DEVE vir antes de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();