using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Generador.GenerarXML(); 

var builder = WebApplication.CreateBuilder(args);

// 🔹 Agregar los servicios que faltaban
builder.Services.AddAuthorization(); 
builder.Services.AddRazorPages();    

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization(); 

app.MapRazorPages();
app.Run();