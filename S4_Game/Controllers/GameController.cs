using S4_Game.Groups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S4_Game
{

    internal class GameController
    {
        /** This class is controlling main game cycle, 
         *  player's inputs, other controllers. **/

        private DrawController DrawControl;
        private CollisionController CollisionController;

        private EnemyGroup EnemyGroup;
        private ProjectileGroup ProjectileGroup;
        private ParticleGroup ParticleGroup;
        private Player Player;

        public int PlayerAcceleration { get { return Player.Acceleration; } set { Player.Acceleration = value; } }

        // Required to constraint object in pictureBox
        private int _fieldWidth;
        private int _fieldHeight;

        private Timer timer = new Timer();

        // End game label
        private Label EndLabel;

        public GameController(PictureBox pictureBox, Label endLabel)
        {
            DrawControl = new DrawController(pictureBox);
            _fieldWidth = pictureBox.Width;
            _fieldHeight = pictureBox.Height;

            SetupPlayer();
            SetupEnemyList();
            SetupProjectileList();
            CollisionController = new CollisionController(EnemyGroup.Enemies, ProjectileGroup.Projectiles, Player);
            ParticleGroup = new ParticleGroup();

            EndLabel = endLabel;

            timer.Interval = 8;
            timer.Tick += new EventHandler(GameEvent);

            timer.Start();
        }

        private void GameEvent(object sender, EventArgs e)
        {
            // Entities drawing
            DrawControl.DrawEntities(EnemyGroup.Enemies, ProjectileGroup.Projectiles, ParticleGroup.Particles, Player);

            // Player movement if player lives
            if (!Player.Update(_fieldWidth))
            {
                EndLabel.Visible = true;
                timer.Tick -= GameEvent;
            }

            if (!EnemyGroup.Update(ProjectileGroup))
            {
                EnemyGroup.SetupEnemies();
                //EndLabel.Text = "Enemies are defeated";
                //EndLabel.Visible = true;
                //timer.Tick -= GameEvent;
            }

            ProjectileGroup.Update();
            ParticleGroup.Update();

            CollisionController.CheckCollision(ParticleGroup);
        }

        public void ShootProjectile()
        {
            Image im = Image.FromFile(GetAsset("bullet.png"));

            ProjectileGroup.AddProjectile(Player.Position, Projectile.PlayerProj);
        }

        private void SetupPlayer()
        {
            Image im = Image.FromFile(GetAsset("player.png"));

            Player = new Player(im, new Point(_fieldWidth / 2, _fieldHeight * 5 / 6));
        }

        private void SetupEnemyList()
        {
            EnemyGroup = new EnemyGroup(_fieldWidth, _fieldHeight);
        }

        private void SetupProjectileList()
        {
            ProjectileGroup = new ProjectileGroup(_fieldWidth, _fieldHeight);
        }

        public static string GetAsset(string asset)
        {
            // This will get the current Assets directory
            return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + $@"\S4_Game\Assets\{asset}";
        }
    }
}
