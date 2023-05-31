using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Game
{
    internal class EnemyGroup
    {
        public List<DrawableObject> Enemies { get; private set; } = new List<DrawableObject>();
        private Random random = new Random();

        // Size of enemy formation
        public int EnemyWidth { get; private set; } = 9;
        public int EnemyHeight { get; private set; } = 4;

        // Required to constraint object in pictureBox
        private int _fieldWidth;
        private int _fieldHeight;

        private int CurrentTick = 0;
        private int EnemyOffset = 0;

        private Image AlienImage = Image.FromFile(GameController.GetAsset("alien.png"));

        public EnemyGroup(int fieldWidth, int fieldHeight)
        {
            _fieldWidth = fieldWidth;
            _fieldHeight = fieldHeight;

            SetupEnemies();
            EnemyOffset = random.Next(-2, 3);

        }

        public bool Update(ProjectileGroup projectileGroup)
        {
            CurrentTick++;
            if (CurrentTick > 50)
            {
                EnemyOffset = random.Next(-2, 3);
                CurrentTick = 0;
            }

            if (Enemies.Count == 0)
                return false;

            // Checks if enemies stays within border
            if (Enemies[0].Center.X + EnemyOffset < 20 ||
                Enemies[Enemies.Count-1].Center.X + EnemyOffset > _fieldWidth - 20
                )
                return true;

            int newX;
            int isShooting;
            foreach (var enemy in Enemies)
            {
                // Since there're too many enemies to control individually,
                // they'll be controlled by GameController
                newX = enemy.Position.X + EnemyOffset;
                enemy.Position = new Point(newX, enemy.Position.Y);

                isShooting = random.Next(0, 101);
                if (isShooting > 99)
                    projectileGroup.AddProjectile(enemy.Position, Projectile.EnemyProj);
            }

            // Returns true if enemies still present
            return true;
        }

        public void SetupEnemies()
        {
            for (int x = _fieldWidth / 10; x < _fieldWidth * EnemyWidth / 10; x += _fieldWidth / 10)
                for (int y = _fieldWidth / 16; y < _fieldWidth * EnemyHeight / 16; y += _fieldWidth / 16)
                    Enemies.Add(new Entity(AlienImage, new Point(x, y)));
        }
    }
}
