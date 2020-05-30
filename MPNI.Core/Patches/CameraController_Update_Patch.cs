using Harmony;
using MPNI.Core.Patches.Abstract;
using UnityEngine;

namespace MPNI.Core.Patches
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
