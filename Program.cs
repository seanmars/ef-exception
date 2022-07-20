using ef_exception;
using Microsoft.EntityFrameworkCore;

WebApplication? CreateApplication()
{
    try
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;
        var services = builder.Services;

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        return app;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

    return default;
}

try
{
    var app = CreateApplication();
    if (app == null)
    {
        return;
    }

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}