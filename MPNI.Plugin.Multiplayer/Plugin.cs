using System;
using MPNI.Core.Plugins;
using MPNI.Core.Plugins.Api;

namespace MPNI.Plugin.Multiplayer
{
    public class Plugin : IPlugin
    {
        public void Start()
        {
            Mouse.Moved += (sender, args) =>
            {
                Console.WriteLine($"Mouse moved: {args.X}, {args.Y}");
            };
        }
    }
}