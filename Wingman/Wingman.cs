using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Wingman.Plugin;

namespace Wingman
{
    class Wingman
    {
        private Config.RootObject _config = null;
        private string _configFile = null;
        private string _configJson = null;
        private readonly Dictionary<string, IPlugin> _plugins = new Dictionary<string, IPlugin>();

        private const string PluginSuffix = "*.x.dll";
        private const string PluginPath = "plugins/";

        public Wingman(string config)
        {
            _configFile = config;
            _configJson = File.ReadAllText(_configFile);
        }

        public void LoadPlugins()
        {
            ICollection<IPlugin> plugins = PluginLoader.LoadPlugins(PluginPath, PluginSuffix);
            foreach (IPlugin plugin in plugins)
            {
                _plugins.Add(plugin.Name, plugin);
            }
        }

        public bool CheckConfig()
        {
            return true;
        }

        public void ParseConfig()
        {
            _config = JsonConvert.DeserializeObject<Config.RootObject>(_configJson);
        }

        public void Execute()
        {
            RestRequest request = new RestRequest(_config.Endpoint);
            foreach (var parameter in _config.Params)
            {
                string key = parameter.Key;
                string value = parameter.Value;
                if (parameter.UsePlugin)
                {
                    (key, value) = _plugins[_config.PluginName].GetData(parameter.PluginKey);
                }
                request.AddParameter(key, value, ParameterType.GetOrPost);
            }
            foreach (var header in _config.Headers)
            {
                string key = header.Name;
                string value = header.Value;
                if (header.UsePlugin)
                {
                    (key, value) = _plugins[_config.PluginName].GetData(header.PluginKey);
                }
                request.AddHeader(key, value);
            }
            Enum.TryParse(_config.Method, out Method method);
            request.Method = method;
            request.Timeout = _config.Timeout;
            RestClient client = new RestClient(_config.Host);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
