using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game.Entities
{
    internal class Particle: Entity
    {
        public int CurrentTimer = 5;
        public Particle(Image image, Point position) : base(image, position)
        {
            Image = image;
            Position = position;
        }

        public void Update()
        {
            CurrentTimer--;
        }
    }
}
