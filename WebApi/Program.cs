using Application.interfaces;
using Application.services;
using infrastructure.Context;
using infrastructure.Dao;
using infrastructure.interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IActivesService, ActivesService>();
builder.Services.AddScoped<IAccountService, AccountsService>();
builder.Services.AddScoped<ITickerDao, TickerDao>();
builder.Services.AddScoped<IAccountDao, AccountDao>();
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>();
        builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();