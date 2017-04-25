using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Wingman.Plugin;

namespace Wingman
{
    /*
     * Developer Note:
     * To use other's plugin downloaded from the web, right click on the dll first and click "Unblock" or check "Allow"!
     */
    // todo: Add exception message if plugin cannot be loaded (see note)
    public static class PluginLoader
    {
        public static ICollection<IPlugin> LoadPlugins(string path, string suffix)
        {
            if (Directory.Exists(path))
            {
                var dllFileNames = Directory.GetFiles(path, suffix);

                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                foreach (Assembly assembly in from dllFile in dllFileNames select AssemblyName.GetAssemblyName(dllFile) into an select Assembly.Load(an))
                {
                    assemblies.Add(assembly);
                }

                ICollection<Type> pluginTypes = (from assembly in assemblies where assembly != null from type in assembly.GetTypes() where type.IsClass && !type.IsAbstract && typeof(IPlugin).IsAssignableFrom(type) select type).ToList();

                ICollection<IPlugin> plugins = new List<IPlugin>(pluginTypes.Count);
                foreach (IPlugin plugin in pluginTypes.Select(type => (IPlugin)Activator.CreateInstance(type)))
                {
                    plugins.Add(plugin);
                }

                return plugins;
            }

            return null;
        }
    }
}