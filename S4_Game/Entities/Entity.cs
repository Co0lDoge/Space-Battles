using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class Entity : DrawableObject
    {
        /** This is base class for all entities **/
        public Entity(Image image, Point position) : base(image, position)
        {
            Image = image;
            Position = position;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(base.Image, base.Position);
        }
    }
}
