using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Hangfire.Mongo.Migration.Strategies;
using MongoDB.Driver;
using Consulta.DataBase.EF;
using Microsoft.EntityFrameworkCore;
using Consulta.Servicos;
using Consulta.Domain.Consulta;
using Hangfire.Storage.SQLite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoUrlBuilder = new MongoUrlBuilder("mongodb://localhost/admin");
var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

//// Add Hangfire services. Hangfire.AspNetCore nuget required
//builder.Services.AddHangfire(configuration => configuration
//    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
//    .UseSimpleAssemblyNameTypeSerializer()
//    .UseRecommendedSerializerSettings()
//    .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, new MongoStorageOptions
//    {
//        MigrationOptions = new MongoMigrationOptions
//        {
//            MigrationStrategy = new MigrateMongoMigrationStrategy(),
//            BackupStrategy = new CollectionMongoBackupStrategy()
//        },
//        Prefix = "hangfire.mongo",
//        CheckConnection = true
//    })
//);
builder.Services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage());

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=consultas.db"));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer(serverOptions =>
{
    serverOptions.ServerName = "Hangfire server 1";
});

builder.Services.AddScoped<IServiceConulta, ServConsulta>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHangfireDashboard();
app.UseAuthorization();

app.MapControllers();

app.Run();
