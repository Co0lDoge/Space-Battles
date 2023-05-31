using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class Player : Entity
    {
        public int Acceleration { get; set; }
        public int HP { get; set; } = 3;

        public Player(Image image, Point position) : base(image, position)
        {
            Image = image;
            Position = position;
        }

        public bool Update(int border)
        {
            // Returns true is player lives;
            int newX = Center.X + Acceleration;
            if (newX > 20 && newX < border - 20)
                Center = new Point(newX, Center.Y);

            if (HP < 1)
                return false;
            return true;
        }
    }
}
