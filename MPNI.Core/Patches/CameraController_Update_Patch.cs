using System.Reflection;
using Harmony;
using MPNI.Core.Patches.Abstract;
using MPNI.Core.Plugins.Api;
using MPNI.Core.Plugins.Api.Events;
using UnityEngine;

namespace MPNI.Core.Patches
{
    internal class CameraController_Update_Patch : ONIPatch
    {
        private static readonly MethodInfo TargetMethod =
            typeof(CameraController).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);

        private static MouseMoveEventArgs lastMoveEvent;

        public static void Postfix()
        {
            var cursorPos = Shader.GetGlobalVector("_WorldCursorPos");
            var moveEvent = new MouseMoveEventArgs(cursorPos.x, cursorPos.y);
            if (lastMoveEvent != moveEvent)
            {
                Mouse.OnMoved(moveEvent);
                lastMoveEvent = moveEvent;
            }
        }

        public override void Patch(HarmonyInstance harmony)
        {
            PatchPostfix(harmony, TargetMethod);
        }
    }
}