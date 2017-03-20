using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker.Model
{
    class Rectangle
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
    }
}


