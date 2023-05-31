using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    abstract internal class DrawableObject
    {
        public Image Image { get; set; }
        public Point Position { get; set; }
        public Point Center
        {
            get { return new Point(Position.X + Image.Width / 2, Position.Y + Image.Height / 2); }
            set { Position = new Point(value.X - Image.Width / 2, value.Y - Image.Height / 2); }
        }

        public DrawableObject(Image image, Point position)
        {
            this.Image = image;
            this.Position = position;
        }

        abstract public void Draw(Graphics graphics);

        public static double GetDistance(DrawableObject ob1, DrawableObject ob2)
        {
            return Math.Sqrt(Math.Pow(ob1.Center.X - ob2.Center.X, 2) + Math.Pow(ob1.Center.Y - ob2.Center.Y, 2));
        }
    }
}
