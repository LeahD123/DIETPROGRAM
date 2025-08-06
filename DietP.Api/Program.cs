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
// הוספת שירותי CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()  // הוסף את ה-Origin שלך כאן
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// רישום של AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// קריאת מחרוזת החיבור ממשתני הסביבה
var connectionString =  Environment.GetEnvironmentVariable("ConnectionStrings_DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string is not set.");
}
builder.Services.AddDbContext<DietContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0))));

// רישום של IDataRepository
builder.Services.AddScoped<IDataRepository, DataRepository>(); 
// רישום של IUserService
builder.Services.AddScoped<IUserService, UserService>();
//רישום של IFoodsItemRepository
builder.Services.AddScoped<IFoodsItemService, FoodsItemService>();
//רישום של ISportRepository
builder.Services.AddScoped<ISportService, SportService>();
//רישום של ICalendarRepository
builder.Services.AddScoped<ICalendarService, CalendarService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAllOrigins");
//שימוש במדיניות CORS
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
