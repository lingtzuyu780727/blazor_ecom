using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// note 注意AddDbContextPool  (有一群在Pool中) 跟 AddDbContext (每次req就建立) 的差別
builder.Services.AddDbContextPool<ShopOnlineDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ShopOnlineConnection"))
);

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
