namespace SpriteTester.HelperClasses;

/// <summary>
/// Option Class for the Playground
/// </summary>
/// <remarks>
/// Initializes Playground options with all required Data
/// </remarks>
/// <param name="idle">Array of Idle Sprites</param>
/// <param name="walking">Array of Walking Sprites</param>
/// <param name="jumping">Array of Jumping Sprites</param>
/// <param name="action">Array of Action Sprites</param>
/// <param name="spriteDelay">Animation Delay in Milliseconds</param>
/// <param name="viewType">The view type of the Playground</param>
public struct PGOptions(Sprite[] idle, Sprite[] walking, Sprite[] jumping, Sprite[] action, int spriteDelay, ViewType viewType, Image? background)
{
    public Sprite[] idleSprites = idle;
    public Sprite[] walkingSprites = walking;
    public Sprite[] jumpingSprites = jumping;
    public Sprite[] actionSprites = action;

    public int spriteDelay = spriteDelay;
    public ViewType viewType = viewType;
    public Image? background = background;
}