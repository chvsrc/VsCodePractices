// Dependency Injection (DI) is a way to provide objects that a class needs (its dependencies) from outside the class.
// Instead of the class creating its own objects, we pass them in. This makes the code easier to test and maintain.

// Example without DI:
// public class Service
// { private Repository repo = new Repository(); // tightly coupled}

// Example with DI:
// public class Service
// {
//     private IRepository repo;
//     public Service(IRepository repository)
//     {
//         repo = repository;
//     }
// }

using Microsoft.Extensions.DependencyInjection;

using Microsoft.ApplicationInsights.WorkerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Program class
/// </summary>
[ExcludeFromCodeCoverage]
public static class Program
{
    /// <summary>
    /// Build service and run services.
    /// </summary>
    /// <param name="services">Service collection</param>
    public static void BuildServiceAndRun(ServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        var appInsightsConnectionString = configuration.GetConnectionString(Constants.AppInsightsConnectionString);

        // Register GenMan services
        services.ConfigureServices(configuration);

        services.AddDbContext<WebApp1Context>();
        services.AddDbContext<DbContext1>();
        services.AddDbContext<DbContext2>();
        services.AddDbContext<DbContext3>();

        services.AddTransient<RestClient>();
        services.AddTransient<AppTelemetryClient>();

        services.AddScoped<ValidateAndDataService>();
        services.AddScoped<DatabaseSettingsReader>();

        services.AddScoped<IService3, Service1>();
        services.AddScoped<IService2, Service2>();
        services.AddScoped<IService1, Service3>();

        // Application Insights
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddFilter<ApplicationInsightsLoggerProvider>("Category", LogLevel.Information);
        });
        services.AddApplicationInsightsTelemetryWorkerService(
        (ApplicationInsightsServiceOptions options) =>
        {
            options.ConnectionString = appInsightsConnectionString;
            options.EnableDependencyTrackingTelemetryModule = false;
        });

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Obtain TelemetryClient instance from DI, for additional manual tracking or to flush.
        var appTelemetryClient = serviceProvider.GetRequiredService<SealTelemetryClient>();

        appTelemetryClient.WriteToTraceAndConsole("CONFIGURATION COMPLETED SUCCESSFULLY");

        serviceProvider.GetRequiredService<ValidateAndDataService>().Run(configuration).Wait();
    }
}

//// DbContext1
[ExcludeFromCodeCoverage]
public partial class DbContext1 : DbContext
{
    public DbSet<Table1> table1 => Set<Table1>();
    public DbSet<Table2> table2 => Set<Table2>();

    public virtual IQueryable<TEntity> RunSql<TEntity>(string sql) where TEntity : class
    {
        return this.Set<TEntity>().FromSqlRaw(sql);
    }

    public virtual IQueryable<TEntity> RunSql<TEntity>(string sql, params object[] parameters)
        where TEntity : class
    {
        return this.Set<TEntity>().FromSqlRaw(sql, parameters);
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
        var connectionString = configuration.GetConnectionString(Constants.HisConnection);
        optionsBuilder.UseSqlServer(connectionString);
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder?.Entity<Table1>().HasNoKey();
        modelBuilder?.Entity<Table2>().HasNoKey();
    }
}