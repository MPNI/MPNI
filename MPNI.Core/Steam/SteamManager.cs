using System;
using Steamworks;

namespace MPNI.Core.Steam
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
