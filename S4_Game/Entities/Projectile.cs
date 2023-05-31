using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class Projectile : Entity
    {
        public bool Type;

        public static bool PlayerProj = true;
        public static bool EnemyProj = false;

        public Projectile(Image image, Point position, bool type) : base(image, position)
        {
            Image= image;
            Position= position;

            Type = type;
        }

        public void Update()
        {
            if (Type == PlayerProj) Position = new Point(Position.X, Position.Y - 5);
            else Position = new Point(Position.X, Position.Y + 5);
        }
    }
}
