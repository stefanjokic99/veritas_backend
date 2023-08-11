using veritas_backend.Manager;

namespace veritas_backend.Extensions
{
    public static class PluginServiceExtensions
    {
        public static IServiceCollection AddPluginServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(provider => new PluginManager(config));

            var pluginManager = services.BuildServiceProvider().GetRequiredService<PluginManager>();

            foreach (var plugin in pluginManager.Plugins)
            {
                services.AddHttpClient(plugin.Key, httpClient =>
                {
                    httpClient.BaseAddress = new Uri(plugin.Value);
                });
            }

            return services;
        }
    }
}
