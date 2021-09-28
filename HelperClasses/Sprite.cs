﻿using System.Drawing;

namespace SpriteTester.HelperClasses
{
    public class Sprite
    {
        public Image image;
        public Direction direction;

        public Sprite(Image image, Direction direction)
        {
            this.image = image;
            this.direction = direction;
        }
    }
}
