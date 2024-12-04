using SpriteTester.HelperClasses;

namespace SpriteTester.Forms;

public partial class PlaygroundForm : Form
{
    private PGOptions options;

    public Image[][][] sprites; // Ordered in [ActionType][Direction][num]

    Character zyra; // Character Class as Renderable

    private float aspectRatio;

    Graphics g;
    BufferedGraphics buffer;

    int platformHeight;

    int phase = 0;

    public PlaygroundForm(PGOptions options)
    {
        InitializeComponent();

        this.options = options;

        zyra = new Character
        {
            posY = Height / 2,
            posX = Width / 2
        };
        platformHeight = Height / 2;

        g = CreateGraphics();
        buffer = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle);

        sprites = RemapSprites();

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
    }

    private void PlaygroundForm_Load(object sender, EventArgs e)
    {
        if (options.background != null)
        {
            aspectRatio = (float)options.background.Size.Width / options.background.Size.Height;
            SizeChange(null, null);
        }
    }

    private void NoSprite()
    {
        MessageBox.Show("No Idle sprite in each required Direction", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Close();
    }

    private void SizeChange(object? sender, EventArgs? e)
    {
        if (g == null) return;
        buffer = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle);

        if (WindowState == FormWindowState.Maximized)
            WindowState = FormWindowState.Normal;
        if (options.background != null)
            Width = (int)(aspectRatio * Height);
        zyra.posX = Width / 2;
        if (options.viewType == ViewType.TopDown) zyra.posY = Height / 2;
        Refresh();
    }

    /// <summary>
    /// Event Handler for the Timer Tick Event; Logic Loop
    /// </summary>
    /// <param name="sender">Event sender</param>
    /// <param name="e">Event Arguments</param>
    private void TimerTick(object sender, EventArgs e)
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
        if (options.background != null)
            buffer.Graphics.DrawImage(options.background, 0, 0, Width, Height);
        else
            buffer.Graphics.Clear(Color.Black);

        buffer.Graphics.DrawImage(
            SpriteExist(zyra.actiontype, zyra.facing) ? 
            sprites[(int)zyra.actiontype][(int)zyra.facing][phase] : 
            sprites[(int)ActionType.Idle][(int)zyra.facing][phase], 
            new Point(zyra.posX, zyra.posY)
        );

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
    private Image[][][] RemapSprites()
    {
        List<Image[][]> sprites = [];
        foreach (ActionType at in Enum.GetValues<ActionType>())
        {
            List<Image[]> spritesAT = [];
            Sprite[] source = at switch
            {
                ActionType.Idle => options.idleSprites,
                ActionType.Walking => options.walkingSprites,
                ActionType.Jumping => options.jumpingSprites,
                ActionType.Acting => options.actionSprites,
                _ => [],
            };
            sprites.Add(Enum.GetValues<Direction>().Select(dir => source.Where(s => s.direction == dir).Select(s => s.image).ToArray()).ToArray());
        }
        return [.. sprites];
    }


    // Key Down Event; Do stuff ig
    private void KeyMove(object sender, KeyEventArgs e)
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

    private void StopMove(object sender, KeyEventArgs e)
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
