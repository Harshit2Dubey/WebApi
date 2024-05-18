using Console_webapi.Data;
using Console_webapi.Functionalities;
using Console_webapi.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  //automatically searches for automapper class
builder.Services.AddTransient<IEmployeeOperation, EmployeeService>(); //if we apply DI then container will create an object of EmployeeService class explicitly.
builder.Services.AddDbContext<EmployeeDBcontext>(); // unity container will create an object of EmployeeDBcontext class based on AddScope.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();
app.Run();


