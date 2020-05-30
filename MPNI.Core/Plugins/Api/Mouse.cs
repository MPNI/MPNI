using System;
using MPNI.Core.Plugins.Api.Events;

namespace MPNI.Core.Plugins.Api
{
    public static class Mouse
    {
        /// <summary>
        ///     Event that gives X and Y position of the current tile the cursor is on in the world.
        /// </summary>
        public static event EventHandler<MouseMoveEventArgs> WorldPositionChanged;

        internal static void OnWorldPositionChanged(MouseMoveEventArgs e)
        {
            WorldPositionChanged?.Invoke(null, e);
        }
    }
}