using Microsoft.Extensions.DependencyInjection;

namespace HR_LeaveManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services) 
    {
        return services;
    }
}