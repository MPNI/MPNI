using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Harmony;
using MPNI.Core.Patches.Abstract;
using MPNI.Core.Plugins;
using static MPNI.Core.Plugins.Api.Logger;

namespace MPNI.Core
{
    public static class Patcher
    {
        public static void Execute()
        {
            PatchAll(HarmonyInstance.Create("MPNI"));
            LoadPlugins();
        }

        private static void PatchAll(HarmonyInstance instance)
        {
            IEnumerable<Type> patches = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(ONIPatch).IsAssignableFrom(t) && !t.IsAbstract);

            Log("Applying patches");
            foreach (Type type in patches)
            {
                ONIPatch patch = (ONIPatch)Activator.CreateInstance(type);
                Log($"Patch: {type.FullName}");
                patch.Patch(instance);
            }
            Log("Patching finished");
        }

        private static void LoadPlugins()
        {
            string pluginDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plugins");
            Log("Loading plugins");
            int pluginsLoaded = 0;
            foreach (var dll in Directory.GetFileSystemEntries(pluginDir, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var plugin = Assembly.Load(dll);
                foreach (var pluginType in plugin.GetTypes().Where(t => !t.IsAbstract && typeof(IPlugin).IsAssignableFrom(t)))
                {
                    try
                    {
                        var pluginInstance = Activator.CreateInstance(pluginType) as IPlugin;
                        if (pluginInstance != null)
                        {
                            pluginInstance.Start();
                            Log(pluginType.FullName);
                        }
                        pluginsLoaded++;
                    }
                    catch (Exception ex)
                    {
                        Log($"Error loading plugin '{pluginType}':{Environment.NewLine}{ex}");
                    }
                }
            }
            Log($"Loaded {pluginsLoaded} plugins");
        }
    }
}
