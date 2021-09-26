using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpriteTester.HelperClasses
{
    /// <summary>
    /// Option Class for the Playground
    /// </summary>
    public class PGOptions
    {
        public Sprite[] idleSprites;
        public Sprite[] walkingSprites;
        public Sprite[] jumpingSprites;
        public Sprite[] actionSprites;

        public int spriteDelay;
        public ViewType viewType;
        public Image background;

        /// <summary>
        /// Initializes empty Playground options
        /// </summary>
        public PGOptions() { }

        /// <summary>
        /// Initializes Playground options with all required Data
        /// </summary>
        /// <param name="idle">Array of Idle Sprites</param>
        /// <param name="walking">Array of Walking Sprites</param>
        /// <param name="jumping">Array of Jumping Sprites</param>
        /// <param name="action">Array of Action Sprites</param>
        /// <param name="spriteDelay">Animation Delay in Milliseconds</param>
        /// <param name="viewType">The view type of the Playground</param>
        public PGOptions(Sprite[] idle, Sprite[] walking, Sprite[] jumping, Sprite[] action, int spriteDelay, ViewType viewType, Image background)
        {
            this.idleSprites = idle;
            this.walkingSprites = walking;
            this.jumpingSprites = jumping;
            this.actionSprites = action;

            this.spriteDelay = spriteDelay;
            this.viewType = viewType;
            this.background = background;
        }
    }
}
