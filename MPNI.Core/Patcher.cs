using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Harmony;
using MPNI.Core.Patches.Abstract;

namespace MPNI.Core
{
    public static class Patcher
    {
        public static void Execute()
        {
            PatchAll(HarmonyInstance.Create("MPNI"));
        }

        public static void PatchAll(HarmonyInstance instance)
        {
            IEnumerable<Type> patches = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableFrom(typeof(ONIPatch)) && !t.IsAbstract);

            Console.WriteLine("[MPNI] Applying patches");
            foreach (Type type in patches)
            {
                ONIPatch patch = (ONIPatch)Activator.CreateInstance(type);
                Console.WriteLine($"[MPNI] Patch: {type.FullName}");
                patch.Patch(instance);
            }
            Console.WriteLine("[MPNI] Patching finished");
        }
    }
}
