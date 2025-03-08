using Taxually.BizLogic.TechnicalTest;
using Taxually.BizLogic.TechnicalTest.Registration;
using Taxually.Contracts.TechnicalTest;
using Taxually.TechnicalTest.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IVatRegistration, DeRegistration>();
builder.Services.AddTransient<IVatRegistration, FrRegistration>();
builder.Services.AddTransient<IVatRegistration, GbRegistration>();
builder.Services.AddSingleton<IVatRegistrationFactory, VatRegistrationFactory>();

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
