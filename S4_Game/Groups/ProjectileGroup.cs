using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class ProjectileGroup
    {
        public List<Projectile> Projectiles = new List<Projectile>();

        // Required to constraint object in pictureBox
        private int _fieldWidth;
        private int _fieldHeight;

        Image PlayerBullet = Image.FromFile(GameController.GetAsset("Bullet.png"));
        Image EnemyBullet = Image.FromFile(GameController.GetAsset("EnemyBullet.png"));

        public ProjectileGroup(int fieldWidth, int fieldHeight) {
            _fieldWidth = fieldWidth;
            _fieldHeight = fieldHeight;
        }

        public void Update()
        {
            foreach (var projectile in Projectiles)
            {
                if (projectile.Position.Y < 0 || projectile.Position.Y > _fieldHeight)
                {
                    Projectiles.Remove(projectile);
                    break;
                }

                projectile.Update();
            }
        }

        //public void AddProjectile(Projectile projectile)
        //{
        //    Projectiles.Add(projectile);
        //}

        public void AddProjectile(Point point, bool type)
        {
            Image BulletImage;
            if (type == Projectile.PlayerProj)
                BulletImage = PlayerBullet;
            else BulletImage = EnemyBullet;


            Projectiles.Add(new Projectile(BulletImage, point, type));
        }
    }
}
