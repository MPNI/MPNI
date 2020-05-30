using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MPNI.Patches.Abstract;

namespace MPNI
{
    public static class Patcher
    {
        public static void PatchAll(HarmonyInstance instance)
        {
            IEnumerable<Type> patches = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableFrom(typeof(ONIPatch)) && !t.IsAbstract);

            foreach (Type type in patches)
            {
                ONIPatch patch = (ONIPatch)Activator.CreateInstance(type);
                patch.Patch(instance);
            }
        }
    }
}
