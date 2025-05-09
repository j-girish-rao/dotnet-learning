using Ivathu.Madu.Api.Configure;
using Ivathu.Madu.DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterService();

builder.Services.AddDbContext<MyDailyTakeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddApiVersioning(opt =>
//{
//    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
//    opt.AssumeDefaultVersionWhenUnspecified = true;
//    opt.ReportApiVersions = true;
//    opt.ApiVersionReader = ApiVersionReader.Combine(
//        new UrlSegmentApiVersionReader(),
//        new HeaderApiVersionReader("x-api-version"),
//        new MediaTypeApiVersionReader("x-api-version"));
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
