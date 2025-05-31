using System.Text.Json;
using ProyectoFinal.Modelos;
using ProyectoFinal.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

//Registro de servicios como Singleton para compartir datos cargados
builder.Services.AddSingleton<ClienteS>();
builder.Services.AddSingleton<TarjetaS>();

var app = builder.Build();

//Carga inicial de datos.json usando deserialización insensible a mayúsculas
try
{
    string rutaJson = Path.Combine(AppContext.BaseDirectory, "datos.json");
    if (File.Exists(rutaJson))
    {
        var json = File.ReadAllText(rutaJson);

        //Deserialización ignorando mayúsculas/minúsculas
        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var datos = JsonSerializer.Deserialize<DatosIniciales>(json, opciones);

        // Obtiene las instancias de los servicios ya registrados
        var clienteService = app.Services.GetRequiredService<ClienteS>();
        var tarjetaService = app.Services.GetRequiredService<TarjetaS>();

        if (datos.Clientes != null)
        {
            foreach (var c in datos.Clientes)
                clienteService.AgregarCliente(c);
        }

        if (datos.Tarjetas != null)
        {
            foreach (var t in datos.Tarjetas)
                tarjetaService.AgregarTarjeta(t);
        }

        Console.WriteLine("Datos iniciales cargados correctamente.");
    }
    else
    {
        Console.WriteLine("No se encontró datos.json.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error al cargar datos.json: {ex.Message}");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();