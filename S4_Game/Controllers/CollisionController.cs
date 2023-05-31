using S4_Game.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class CollisionController
    {
        private List<DrawableObject> Enemies;
        private List<Projectile> Projectiles;
        private Player Player;

        public CollisionController(List<DrawableObject> enemies, List<Projectile> projectiles, Player player)
        {
            Enemies = enemies;
            Projectiles = projectiles;
            Player = player;
        }

        public void CheckCollision(ParticleGroup particleGroup)
        {
            bool collided = false;
            foreach (var projectile in Projectiles)
            {
                // Checks collision of player
                if (projectile.Type == Projectile.EnemyProj && DrawableObject.GetDistance(projectile, Player) < 20)
                {
                    Player.HP--;
                    Projectiles.Remove(projectile);
                    collided = true;
                    break;
                }

                if (collided) break;

                // Checks collision of enemies
                foreach (var enemy in Enemies)
                    if (projectile.Type == Projectile.PlayerProj && DrawableObject.GetDistance(projectile, enemy) < 20)
                    {
                        particleGroup.AddParticle(enemy.Position);

                        Enemies.Remove(enemy);
                        Projectiles.Remove(projectile);
                        collided = true;
                        break;
                    }

                if (collided) break;
            }
        }
    }
}
