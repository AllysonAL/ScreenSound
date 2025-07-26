using Microsoft.EntityFrameworkCore;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/", () => 
{
    var context = new ScreenSoundContext(builder.Configuration.GetConnectionString("DefaultConnection")!);
    var artistaDAL = new DAL<Artista>(context);
    return artistaDAL.Listar();
});

app.Run();
