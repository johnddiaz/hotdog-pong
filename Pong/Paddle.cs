﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Pong
{
    public enum PlayerTypes
    {
        Human,
        Computer
    }

    public class Paddle : Sprite
    {
        private readonly PlayerTypes playerType;

        //private readonly Rectangle screenBounds;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds, PlayerTypes playerType) 
            : base(texture, location, screenBounds)
        {
            this.playerType = playerType;
            //this.screenBounds = screenBounds;

        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if(playerType == PlayerTypes.Computer)
            {
                // computer follows the ball down
                if(gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y)
                {
                    Velocity = new Vector2(0, -23f);
                }
                // computer follows the ball upp
                if (gameObjects.Ball.Location.Y > Location.Y + Height)
                {
                    Velocity = new Vector2(0, 23f);
                }
            }
            if(playerType == PlayerTypes.Human)
            {
                if (gameObjects.TouchInput.Up)
                {
                    Velocity = new Vector2(0, -17f);
                }

                if (gameObjects.TouchInput.Down)
                {
                    Velocity = new Vector2(0, 17f);
                }
            }

            base.Update(gameTime, gameObjects);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        protected override void CheckBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - texture.Height);
        }
    }
}