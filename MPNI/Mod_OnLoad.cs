using System;
using System.IO;
using System.Reflection;

namespace MPNI
{
    public static class Mod_OnLoad
    {
        public static void OnLoad()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomainOnAssemblyResolve;

            var assembly = Assembly.Load(new AssemblyName("MPNI.Core"));
            assembly.GetType("MPNI.Core.Patcher")
                .InvokeMember("Execute",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
                    null,
                    null,
                    null);
            Log("Loaded");
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dllFileName = args.Name.Split(',')[0];
            if (!dllFileName.EndsWith(".dll"))
            {
                dllFileName += ".dll";
            }

            var entryDllLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dllPath = Path.Combine(entryDllLocation, "bin", dllFileName);
            if (!File.Exists(dllPath))
            {
                dllPath = Path.Combine(entryDllLocation, dllFileName);
            }

            if (!File.Exists(dllPath))
            {
                Log($"DLL reference missing: {dllPath}");
            }
            return Assembly.LoadFile(dllPath);
        }

        private static void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            Console.WriteLine($"[MPNI] {message}");
        }
    }
}