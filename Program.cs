using big_purple_bank.Server.Database;
using BigPurpleBank.Filter;
using BigPurpleBank.Interfaces;
using BigPurpleBank.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IBankingService, BankingService>();

    builder.Services.AddControllers(options =>
    {
        // Add the filter globally
        options.Filters.Add<HeaderValidationFilter>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.OperationFilter<SwaggerHeadersFilter>();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

//using (var serviceScope = app.Services.CreateScope())
//{
//    var DbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
//    await DbContext.Database.MigrateAsync();
//}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
