using System;
using MPNI.Core.Plugins.Api.Events;

namespace MPNI.Core.Plugins.Api
{
    public static class Mouse
    {
        public static event EventHandler<MouseMoveEventArgs> Moved;

        internal static void OnMoved(MouseMoveEventArgs e)
        {
            Moved?.Invoke(null, e);
        }
    }
}