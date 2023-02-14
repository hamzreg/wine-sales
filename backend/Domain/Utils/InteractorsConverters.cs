using Microsoft.Extensions.DependencyInjection;
using WineSales.Domain.ModelConverters;


namespace WineSales.Utils {
    public static class ProvideExtension {
        public static IServiceCollection AddDtoConverters(this IServiceCollection services) {
            services.AddTransient<CustomerConverter>();
            services.AddTransient<SaleConverter>();
            services.AddTransient<SupplierConverter>();
            services.AddTransient<SupplierWineConverter>();
            services.AddTransient<UserConverter>();
            services.AddTransient<WineConverter>();

            return services;
        }
    }
}
