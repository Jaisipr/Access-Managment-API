using Access_Managment_API.DBContext;
using Access_Managment_API.IRepository;
using Access_Managment_API.IServices;
using Access_Managment_API.Repository;
using Access_Managment_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Build absolute path for DB under App_Data in content root
var dataFolder = Path.Combine(builder.Environment.ContentRootPath, "App_Data");
Directory.CreateDirectory(dataFolder); // creates if missing

var dbPath = Path.Combine(dataFolder, "access.db");

// Ensure file exists (optional for EF migrations; SQLite will create if Mode=ReadWriteCreate)
if (!File.Exists(dbPath))
{
    // create empty file and close handle immediately
    using var fs = File.Create(dbPath);
}

// Use SQLite with flags suitable for multi-process/dev
var connectionString = $"Data Source={dbPath};Mode=ReadWriteCreate;Cache=Shared";
builder.Services.AddDbContext<AccessDBContext>(options =>
    options.UseSqlite(connectionString));


builder.Services.AddScoped<IAssetRepository, AssetRepository>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();

builder.Services.AddScoped<IApprovalRepository, ApprovalRepository>();

builder.Services.AddScoped<IUserAssetRepository, UserAssetRepository>();

builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IRequestService, RequestService>();


builder.Services.AddControllers();
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
