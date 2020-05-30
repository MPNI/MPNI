using KMod;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONIMP.Patches.Steam
{
    public class SteamManager
    {
        public SteamManager()
        {
            if (!SteamAPI.IsSteamRunning())
            {
                throw new Exception("Steam not running!");
            }


        }
    }
}
