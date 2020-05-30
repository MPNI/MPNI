using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONIMP
{
    public static class Mod_OnLoad
    {
        public static void OnLoad()
        {
            Debug.Log("ONIMP Mod Loaded");

            HarmonyInstance instance = HarmonyInstance.Create("ONIMP");

            Patcher.PatchAll(instance);
        }
    }
}