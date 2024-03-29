using BICE.SRV;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<GestionMateriel_SRV>(new GestionMateriel_SRV());
builder.Services.AddSingleton<GestionVehicule_SRV>(new GestionVehicule_SRV());
builder.Services.AddSingleton<GestionIntervention_SRV>(new GestionIntervention_SRV());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
