using Access_Managment_API.DBContext;
using Access_Managment_API.IRepository;
using Access_Managment_API.IServices;
using Access_Managment_API.Repository;
using Access_Managment_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AccessDBContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAssetRepository, AssetRepository>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();

builder.Services.AddScoped<IApprovalRepository, ApprovalRepository>();

builder.Services.AddScoped<IUserAssetRepository, UserAssetRepository>();

builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IRequestService, RequestService>();


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
