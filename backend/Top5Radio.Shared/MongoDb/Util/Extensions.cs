using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio
{
    public static class Extensions
    {
        public static void AddTopSongsDatabase(this IServiceCollection services, IConfiguration configuration)
        {            
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
        }
    }
}
