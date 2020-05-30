using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MPNI.Patches.Abstract
{
    internal abstract class ONIPatch
    {
        public abstract void Patch(HarmonyInstance harmony);

        public HarmonyMethod GetHarmonyMethod(string methodName)
        {
            MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (method == null)
            {
                Debug.LogError($"Patcher: Patch method \"{methodName}\" cannot be found");
            }
            return new HarmonyMethod(method);
        }

        protected void PatchTranspiler(HarmonyInstance harmony, MethodBase targetMethod, string transpilerMethod = "Transpiler")
        {
            PatchMultiple(harmony, targetMethod, null, null, transpilerMethod);
        }

        protected void PatchPrefix(HarmonyInstance harmony, MethodBase targetMethod, string prefixMethod = "Prefix")
        {
            PatchMultiple(harmony, targetMethod, prefixMethod);
        }

        protected void PatchPostfix(HarmonyInstance harmony, MethodBase targetMethod, string postfixMethod = "Postfix")
        {
            PatchMultiple(harmony, targetMethod, null, postfixMethod);
        }

        protected void PatchMultiple(HarmonyInstance harmony, MethodBase targetMethod, bool prefix, bool postfix, bool transpiler)
        {
            string prefixMethod = prefix ? "Prefix" : null;
            string postfixMethod = postfix ? "Postfix" : null;
            string transpilerMethod = transpiler ? "Transpiler" : null;

            PatchMultiple(harmony, targetMethod, prefixMethod, postfixMethod, transpilerMethod);
        }

        protected void PatchMultiple(HarmonyInstance harmony, MethodBase targetMethod,
            string prefixMethod = null, string postfixMethod = null, string transpilerMethod = null)
        {
            if (targetMethod == null)
            {
                throw new ArgumentNullException("targetMethod");
            }

            HarmonyMethod harmonyPrefixMethod = prefixMethod != null ? GetHarmonyMethod(prefixMethod) : null;
            HarmonyMethod harmonyPostfixMethod = postfixMethod != null ? GetHarmonyMethod(postfixMethod) : null;
            HarmonyMethod harmonyTranspilerMethod = transpilerMethod != null ? GetHarmonyMethod(transpilerMethod) : null;

            harmony.Patch(targetMethod, harmonyPrefixMethod, harmonyPostfixMethod, harmonyTranspilerMethod);
        }

    }
}
