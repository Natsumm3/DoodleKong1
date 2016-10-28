using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DoodleKong
{
    class Tiles
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        private static ContentManager content;


        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, Color.White);
        }


    }

    class TileCollision : Tiles
    {
        public TileCollision(int i , Rectangle newRect)
        {

            texture = Content.Load<Texture2D>("Tile" + i);
            this.Rectangle = newRect;
        }

    }

}
