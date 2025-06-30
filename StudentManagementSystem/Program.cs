using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementSystem.Data;
using StudentManagementSystem.DAL;
using StudentManagementSystem.DAL.StudentDAL;
using StudentManagementSystem.DAL.StudentCourseDAL;
using StudentManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });


builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<StudentService>();

builder.Services.AddScoped<ICourse,CourseRepository>();
builder.Services.AddScoped<CourseService>();

builder.Services.AddScoped<IStudentCourseRepository,StudentCourseRepository >();
builder.Services.AddScoped<StudentCourseServices>();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();

