using Core.Mapping;
using DietP.Core.Repositories;
using DietP.Core.Services;
using DietP.Infrastructure;
using DietP.Infrastructure.DataRepository;
using DietP.Service.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// ����� ������ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()  // ���� �� �-Origin ��� ���
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// ����� �� AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// ����� ������ ������ ������ ������
var connectionString =  Environment.GetEnvironmentVariable("ConnectionStrings_DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string is not set.");
}
builder.Services.AddDbContext<DietContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0))));

// ����� �� IDataRepository
builder.Services.AddScoped<IDataRepository, DataRepository>(); 
// ����� �� IUserService
builder.Services.AddScoped<IUserService, UserService>();
//����� �� IFoodsItemRepository
builder.Services.AddScoped<IFoodsItemService, FoodsItemService>();
//����� �� ISportRepository
builder.Services.AddScoped<ISportService, SportService>();
//����� �� ICalendarRepository
builder.Services.AddScoped<ICalendarService, CalendarService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAllOrigins");
//����� �������� CORS
 //Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
