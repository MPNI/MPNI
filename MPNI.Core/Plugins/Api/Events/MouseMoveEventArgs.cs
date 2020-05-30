using System;

namespace MPNI.Core.Plugins.Api.Events
{
    public class MouseMoveEventArgs : EventArgs
    {
        public MouseMoveEventArgs(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }
        public float Y { get; }

        protected bool Equals(MouseMoveEventArgs other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MouseMoveEventArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static bool operator ==(MouseMoveEventArgs left, MouseMoveEventArgs right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MouseMoveEventArgs left, MouseMoveEventArgs right)
        {
            return !Equals(left, right);
        }
    }
}