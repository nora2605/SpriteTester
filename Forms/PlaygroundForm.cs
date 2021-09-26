﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteTester.HelperClasses;

namespace SpriteTester.Forms
{
    public partial class PlaygroundForm : Form
    {
        public PGOptions options;

        public Image[][][] sprites; // Ordered in [ActionType][Direction][num]

        Character zyra; // Character Class as Renderable

        private float aspectRatio;
        private bool bgPresent = false;

        Graphics g;
        BufferedGraphics buffer;

        int platformHeight;

        int phase = 0;
        int toIdle = 10;

        public PlaygroundForm()
        {
            InitializeComponent();
            options = new PGOptions();
        }

        private void PlaygroundForm_Load(object sender, EventArgs e)
        {
            zyra = new Character();
            zyra.posY = Height / 2;
            platformHeight = Height / 2;
            zyra.posX = Width / 2;

            timer.Interval = options.spriteDelay;
            timer.Enabled = true;

            g = CreateGraphics();
            buffer = BufferedGraphicsManager.Current.Allocate(g, this.ClientRectangle);

            sprites = remapSprites();

            if (options.background == null)
                return;
            bgPresent = true;

            aspectRatio = (float)options.background.Size.Width / (float)options.background.Size.Height;

            sizeChange(null, null);
        }

        private void sizeChange(object sender, EventArgs e)
        {
            buffer = BufferedGraphicsManager.Current.Allocate(g, this.ClientRectangle);

            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            if (bgPresent)
                Width = (int)(aspectRatio * (float)Height);
            zyra.posX = Width / 2;
            if (options.viewType == ViewType.TopDown) zyra.posY = Height / 2;
            Refresh();
        }

        /// <summary>
        /// Event Handler for the Timer Tick Event; Logic Loop
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event Arguments</param>
        private void timerTick(object sender, EventArgs e)
        {
            // Render
            if (bgPresent)
                buffer.Graphics.DrawImage(options.background, 0, 0, Width, Height);

            if (options.idleSprites.Length == 0)
            {
                timer.Enabled = false;
                MessageBox.Show("You need at least one Idle Sprite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            buffer.Graphics.DrawImage(sprites[(int)ActionType.Idle][(int)Direction.Right][phase], new Point(zyra.posX, zyra.posY));

            buffer.Render(g);

            // Logic
            if (zyra.actiontype != ActionType.Idle)
            {
                toIdle--;
                if (toIdle == 0)
                {
                    zyra.actiontype = ActionType.Idle;
                }
            }
        }

        private void PlaygroundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
            buffer.Dispose();
            g.Dispose();
        }

        private Image[][][] remapSprites()
        {
            List<Image[][]> sprites = new List<Image[][]>();
            foreach (ActionType at in Enum.GetValues(typeof(ActionType)))
            {
                List<Image[]> spritesAT = new List<Image[]>();
                Sprite[] source;
                switch (at)
                {
                    case ActionType.Idle:
                        source = options.idleSprites;
                        break;
                    case ActionType.Walking:
                        source = options.walkingSprites;
                        break;
                    case ActionType.Jumping:
                        source = options.jumpingSprites;
                        break;
                    case ActionType.Acting:
                        source = options.actionSprites;
                        break;
                    default:
                        source = new Sprite[] { };
                        break;
                }
                foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    List<Image> spritesDir = new List<Image>();
                    foreach (Sprite s in source)
                    {
                        if (s.direction == dir)
                            spritesDir.Add(s.image);
                    }
                    spritesAT.Add(spritesDir.ToArray());
                }
                sprites.Add(spritesAT.ToArray());
            }
            return sprites.ToArray();
        }

        private void move(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:

                    break;

                case Keys.S:
                case Keys.Down:

                    break;

                case Keys.A:
                case Keys.Left:

                    break;

                case Keys.D:
                case Keys.Right:

                    break;

                case Keys.Space:
                    zyra.actiontype = ActionType.Jumping;
                    break;

                case Keys.Q:
                case Keys.E:
                    zyra.actiontype = ActionType.Acting;
                    break;
            }
        }
    }
}
