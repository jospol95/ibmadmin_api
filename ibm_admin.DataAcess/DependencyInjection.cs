using ibm_admin.DataAcess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	//public static IServiceCollection AddDatabaseLayer(
 //       this IServiceCollection services, 
 //       IConfiguration configuration)
 //   {
 //       services.AddDbContext<IBMDbContext>(opt =>
 //      {
 //          opt.UseSqlServer(configuration.GetConnectionString("ibm_sql"),
 //              sqlServerOptionsAction: sqlOptions =>
 //              {
 //                   //Configuring Connection Resiliency:
 //                   sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
 //                      maxRetryDelay: TimeSpan.FromSeconds(30),
 //                      errorNumbersToAdd: null);
 //              });
 //      });
 //       return services;
    //}
}
