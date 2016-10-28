using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


namespace DoodleKong
{
    class Player
    {
        private Texture2D texture;
        private Rectangle rect;
        private Vector2 position = new Vector2(64, 460);
        private Vector2 velocity;
        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
        }

        public Player()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("testdoodle");

        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            UserInput(gameTime);

            if (velocity.Y <10)
            {
                velocity.Y += 0.4f;
            }
        }

        private void UserInput(GameTime gameTime)
        {
             if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
             else if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
            else
            {
                velocity.X = 0f;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 15f;
                velocity.Y = -9f;
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newRect, int xOffset, int yOffset)
        {
            if(rect.TouchTop(newRect))
            {
                rect.Y = newRect.Y - rect.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if(rect.TouchLeft(newRect))
            {
                position.X = newRect.X - rect.Width - 2;
            }

            if(rect.TouchRight(newRect))
            {
                position.X = newRect.X + rect.Width + 2;
            }

            if(rect.TouchBottom(newRect))
            {
                velocity.Y = 1f;
            }

            if(position.X < 0)
            {
                position.X = 0;
            }

            if (position.X > xOffset - rect.Width)
            {
                position.X = xOffset - rect.Width;
            }

            if (position.Y < 0)
            {
                velocity.Y = 1f;
            }

            if (position.Y > yOffset - rect.Height)
            {
                position.Y = yOffset - rect.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
