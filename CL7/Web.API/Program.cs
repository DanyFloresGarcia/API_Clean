using Application;
using AspNetCoreRateLimit;
using Infrastructure;
using Serilog;
using Web.API;
using Web.API.Extensions;
using Web.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var useConsole = bool.TryParse(builder.Configuration["Logging:UseConsole"], out var consoleEnabled) && consoleEnabled;

var logConfiguration = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext();

if (useConsole)
{
    logConfiguration.WriteTo.File(builder.Configuration["Serilog:WriteTo:0:Args:path"]);
}
else
{
    logConfiguration.WriteTo.Console();
}

Log.Logger = logConfiguration.CreateLogger();

builder.Host.UseSerilog(); // Asegurate de usar Serilog

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();
            
//Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPortalFinanzas",
        policy =>
        {
            policy.WithOrigins("*")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimitOptions"));

builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();


var app = builder.Build();

app.UseCors("AllowPortalFinanzas");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.UseIpRateLimiting();

app.MapControllers();

app.Run();

