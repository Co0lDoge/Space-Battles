using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class Enemy: Entity
    {
        public Enemy(Image image, Point position) : base(image, position)
        {
            Image = image;
            Position = position;
        }
    }
}
