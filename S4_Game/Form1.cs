using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

using System.Windows.Input;

namespace S4_Game
{
    public partial class Form1 : Form
    {

        GameController gameController;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameController = new GameController(pictureBox1, labelDie);
            labelDie.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    gameController.PlayerAcceleration = -5;
                    break;
                case Keys.D:
                    gameController.PlayerAcceleration = 5;
                    break;

                case Keys.Space:
                    gameController.ShootProjectile();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.D:
                    gameController.PlayerAcceleration = 0;
                    break;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // 1 Second before game starts
            System.Threading.Thread.Sleep(1000);
        }
    }
}
