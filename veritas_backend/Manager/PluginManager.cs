namespace veritas_backend.Manager
{
    public class PluginManager
    {
        public Dictionary<string, string> Plugins { get; private set; }

        public PluginManager(IConfiguration configuration) { LoadPluginsInformations(configuration); }

        private void LoadPluginsInformations(IConfiguration configuration) 
        {
            if (Plugins != null) { return; }

            Plugins = new Dictionary<string, string>();

            var pluginsConfig = configuration.GetSection("Plugins").Get<List<PluginConfig>>();

            foreach (var plugin in pluginsConfig)
            {
                Plugins.Add(plugin.Name, plugin.Uri);
            }
        }

        public bool ContainsPlugin(string pluginName) { return Plugins.ContainsKey(pluginName); }
    }
}
