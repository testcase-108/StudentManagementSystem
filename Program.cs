using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication7.Controllers;
using WebApplication7.CourseDAL;
using WebApplication7.DAL;
using WebApplication7.Data;
using WebApplication7.Extensions;
using WebApplication7.model;
using WebApplication7.StuCourseDAL;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        //.AddJsonOptions(options =>
        //{
        //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        //});

        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<StudentService>();

        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<CourseService>();

        builder.Services.AddScoped<IStuCourseRepository, StuCourseRepository>();
        builder.Services.AddScoped<StuCourseSevice>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your valid token in the text input below"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<String> ()
                }
            });
        });


        builder.Services.DBContextInjection(builder.Configuration)
                        .AddIdentityHandlersAndStores()
                        .AddIdentityAuth(builder.Configuration)
                        .AddAuthorization();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            await SeedData.Initialize(scope.ServiceProvider);
            await SeedData.CreateAdminUser(scope.ServiceProvider);
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.ConfigureCORS(builder.Configuration)
           .AddIdentityAuthMiddleware();
        app.MapGroup("/api");
        app.UseHttpsRedirection();
        app.MapControllers();
        app.MapIdentityUserEndpoints(builder.Configuration)
           .MapAccountEndpoints();

        app.Run();
    }
}
