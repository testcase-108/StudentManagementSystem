namespace WebApplication7.Extensions
{
    public static class AppConfigExtensions
    {
        public static WebApplication ConfigureCORS(this WebApplication app, IConfiguration config)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .WithHeaders("Content-Type")
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader()
        );
            return app;
        }
    }
}
