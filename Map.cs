using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoodleKong
{
    class Map
    {
        private List<TileCollision> tileCollision = new List<TileCollision>();
        private int width;
        private int height;
        

        public List<TileCollision> TileCollision
        {
            get { return tileCollision; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Map()
        {

        }

        public void GenerateMap(int [,] map, int size)
        {
            for(int i = 0; i < map.GetLength(1); i++)
            {
                for(int j =0;j< map.GetLength(0); j++)
                {

                    int numbers = map[j, i];

                    if (numbers>0)
                    {
                        tileCollision.Add(new TileCollision(numbers, new Rectangle(i * size, j * size, size, size)));
                    }

                    width = (i + 1) * size;
                    height = (j + 1) * size;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(TileCollision tile in tileCollision)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
