using S4_Game.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game.Groups
{
    internal class ParticleGroup
    {
        public List<Particle> Particles = new List<Particle>();

        private Image Explosion = Image.FromFile(GameController.GetAsset("Explosion.png"));

        public void Update()
        {
            foreach (var particle in Particles)
            {
                particle.Update();
                if (particle.CurrentTimer < 0)
                {
                    Particles.Remove(particle);
                    break;
                }
                    
            }
        }

        public void AddParticle(Point point)
        {
            Particles.Add(new Particle(Explosion, point));
        }
    }
}
