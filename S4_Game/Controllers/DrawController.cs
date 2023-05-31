using S4_Game.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S4_Game
{
    internal class DrawController
    {
        /** This class is responsible for drawing drawable objects. **/

        private PictureBox _pictureBox;
        private Color _backColor = Color.Black;

        private readonly Graphics _graphics;
        private readonly Image _tempImage;

        public DrawController(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

            _graphics = Graphics.FromImage(_pictureBox.Image);

            // Fills pictureBox with backColor at start
            FillBackground();

            // Saves background image
            _tempImage = (Image)_pictureBox.Image.Clone();
        }

        public void DrawBackground() 
        {
            _graphics.DrawImage(_tempImage, new Point(0, 0));
        }

        // Fills screen with start color at start
        private void FillBackground()
        {
            for (int i = 0; i < _pictureBox.Width; i++)
                for (int j = 0; j < _pictureBox.Height; j++)
                    ((Bitmap)_pictureBox.Image).SetPixel(i, j, _backColor);
        }

        public void DrawEntities(List<DrawableObject> enemies, List<Projectile> projectiles, List<Particle> particles, Player player)
        {
            DrawBackground();

            foreach (var entity in enemies)
            {
                entity.Draw(_graphics);
            }

            foreach (var projectile in projectiles)
            {
                projectile.Draw(_graphics);
            }

            foreach (var particle in particles)
            {
                particle.Draw(_graphics);
            }

            player.Draw(_graphics);

            _pictureBox.Refresh();
        } 
    }
}
