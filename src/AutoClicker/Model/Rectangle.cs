using System;
using System.Windows;

namespace AutoClicker.Model
{
    public class Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;

            Width = width;
            Height = height;

            CenterX = Width / 2 + X;
            CenterY = Height / 2 + Y;
        }

        public Rectangle(double x, double y, double width, double height) : this(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(width), Convert.ToInt32(height))
        {
        }

        public int X { get; }
        public int Y { get; }

        public int Width { get; }
        public int Height { get; }

        public int CenterX { get; }
        public int CenterY { get; }

        public static Rectangle Empty => new Rectangle(0, 0, 0, 0);

        public static Rectangle From(System.Drawing.Rectangle rect)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static Rectangle From(Rect rect)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public bool Equals(Rectangle other)
        {
            if (other == null)
                return false;

            return (X == other.X && Y == other.Y && Width == other.Width && Height == other.Height);
        }

        public static bool operator ==(Rectangle a, Rectangle b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return (a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height);
        }

        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }
    }
}