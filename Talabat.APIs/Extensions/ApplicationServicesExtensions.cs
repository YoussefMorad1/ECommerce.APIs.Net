using Talabat.APIs.Mappers;
using Talabat.DomainLayer.Repositories;
using Talabat.Repository;

namespace Talabat.APIs.Extensions
{
	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
		{
			Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			Services.AddAutoMapper(typeof(MappingProfiles));
			return Services;
		}
	}
}
