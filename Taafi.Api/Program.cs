using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error != null)
        {
            
            var ex = error.Error;

     
            var response = new
            {
                status = 500,
                message = "Global Error",
                detail = ex.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    });
});
app.MapOpenApi();


app.MapScalarApiReference("/scalar", options =>
{
    options.WithTitle("Taafi API");     
    options.WithTheme(ScalarTheme.Moon); 
});


app.MapGet("/", () => Results.Redirect("/scalar"));


// app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();