using Harmony;
using MPNI.Patches.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MPNI.Patches
{
    internal class CameraController_Update_Patch : ONIPatch
    {
        private static float targetTime;
        public static void Postfix()
        {
            if (Time.deltaTime > targetTime)
            {
                Vector4 cursorPos = Shader.GetGlobalVector("_WorldCursorPos");
                targetTime = Time.deltaTime + 0.02f;
            }
        }

        public override void Patch(HarmonyInstance harmony)
        {
        }
    }
}
