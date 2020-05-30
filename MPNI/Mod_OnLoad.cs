using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPNI
{
    public static class Mod_OnLoad
    {
        public static void OnLoad()
        {
            Debug.Log("MPNI Mod Loaded");

            HarmonyInstance instance = HarmonyInstance.Create("MPNI");

            Patcher.PatchAll(instance);
        }
    }
}