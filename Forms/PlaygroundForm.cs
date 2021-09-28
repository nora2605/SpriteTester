using SpriteTester.HelperClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

            g = CreateGraphics();
            buffer = BufferedGraphicsManager.Current.Allocate(g, this.ClientRectangle);

            sprites = remapSprites();

            // Check for Base Idle Sprites (TD)

            if (sprites[(int)ActionType.Idle][(int)Direction.Left].Length == 0
                || sprites[(int)ActionType.Idle][(int)Direction.Right].Length == 0)
            {
                NoSprite();
                return;
            }
            if (options.viewType == ViewType.TopDown && (sprites[(int)ActionType.Idle][(int)Direction.Top].Length == 0
                    || sprites[(int)ActionType.Idle][(int)Direction.Bottom].Length == 0))
            {
                NoSprite();
                return;
            }

            timer.Interval = options.spriteDelay;
            timer.Enabled = true;

            if (options.background == null)
                return;
            bgPresent = true;
            aspectRatio = (float)options.background.Size.Width / (float)options.background.Size.Height;
            sizeChange(null, null);
        }

        private void NoSprite()
        {
            MessageBox.Show("No Idle sprite in each required Direction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
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
            // Logic

            phase = (phase + 1) % GetMaxSprite(SpriteExist(zyra.actiontype, zyra.facing) ? zyra.actiontype : ActionType.Idle, zyra.facing);

            if (zyra.actiontype == ActionType.Walking)
            {
                switch (zyra.facing)
                {
                    case Direction.Left:
                        zyra.posX -= 10;
                        break;
                    case Direction.Right:
                        zyra.posX += 10;
                        break;
                    case Direction.Top:
                        zyra.posY -= 10;
                        break;
                    case Direction.Bottom:
                        zyra.posY += 10;
                        break;
                }
            }

            // Render
            if (bgPresent)
                buffer.Graphics.DrawImage(options.background, 0, 0, Width, Height);
            else
                buffer.Graphics.Clear(Color.Black);

            buffer.Graphics.DrawImage(SpriteExist(zyra.actiontype, zyra.facing) ? sprites[(int)zyra.actiontype][(int)zyra.facing][phase] : sprites[(int)ActionType.Idle][(int)zyra.facing][phase], new Point(zyra.posX, zyra.posY));

            buffer.Render(g);
        }

        //Check if a Sprite exists for given AT and DIR
        private bool SpriteExist(ActionType at, Direction dir)
        {
            return !(sprites[(int)at][(int)dir].Length == 0);
        }

        // Get sprite list length for certain action and direction
        private int GetMaxSprite(ActionType at, Direction dir)
        {
            return sprites[(int)at][(int)dir].Length;
        }

        // Stop timer and dispose Graphics before exiting, might else call again and throw an exception
        private void PlaygroundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
            buffer.Dispose();
            g.Dispose();
        }

        // Remap the Sprites from seperate objects lists with tuples to a 3D array :)
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


        // Key Down Event; Do stuff ig
        private void move(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    if (options.viewType == ViewType.TopDown)
                    {
                        zyra.facing = Direction.Top;
                        zyra.actiontype = ActionType.Walking;
                    }
                    break;

                case Keys.S:
                case Keys.Down:
                    if (options.viewType == ViewType.TopDown)
                    {
                        zyra.facing = Direction.Bottom;
                        zyra.actiontype = ActionType.Walking;
                    }
                    break;

                case Keys.A:
                case Keys.Left:
                    zyra.facing = Direction.Left;
                    zyra.actiontype = ActionType.Walking;
                    break;

                case Keys.D:
                case Keys.Right:
                    zyra.facing = Direction.Right;
                    zyra.actiontype = ActionType.Walking;
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

        private void stopMove(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    if (options.viewType == ViewType.TopDown)
                        zyra.actiontype = ActionType.Idle;
                    break;

                case Keys.S:
                case Keys.Down:
                    if (options.viewType == ViewType.TopDown)
                        zyra.actiontype = ActionType.Idle;
                    break;

                case Keys.A:
                case Keys.Left:
                    zyra.actiontype = ActionType.Idle;
                    break;

                case Keys.D:
                case Keys.Right:
                    zyra.actiontype = ActionType.Idle;
                    break;
            }
        }
    }
}
