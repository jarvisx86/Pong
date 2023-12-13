using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Sprites
{
    public class Ball
    {

        #region Fields

        public int ScorePlayer1 = 0;
        public int ScorePlayer2 = 0;
        public bool inPlay = true;
        public Vector2 Velocity;


        #endregion
        #region Properties

        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
        public SpriteFont ScoreFont { get; set; }  

        #endregion

        #region Constructors

        public Ball(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Width = texture.Width;
            Height = texture.Height;
            Position = position;
            SpeedX = 1.5f;
            SpeedY = 1.5f;
              
        }


        public void Move(Sprite paddle)
        {
            
            if (inPlay == true)

            {

                Velocity.X = SpeedX;
                Velocity.Y = SpeedY;
               
                Position += Velocity;

                if (Position.X <= 10)
                {
                    SpeedX *= -1;
                    ScorePlayer2 += 1;
                    
                }
                else if (Position.X >= 790 - Width)
                {
                    SpeedX *= -1;
                    ScorePlayer1 += 1;
                }
                else if (Position.Y >= 470 - Height)
                {
                    SpeedY *= -1;
                }
                else if (Position.Y <= 10)
                {
                    SpeedY *= -1;
                }

                Rectangle paddleRec = new Rectangle((int)paddle.Position.X, (int)paddle.Position.Y, (int)paddle.Width, (int)paddle.Height);

                Rectangle ballRec = new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height);

                if(HitsPaddle(ballRec, paddleRec))
                {
                    SpeedX *= -1;
                }

            }
        }

        public static bool HitsPaddle(Rectangle r1, Rectangle r2)
        {
            if (Rectangle.Intersect(r1, r2) != Rectangle.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Texture != null)
            {
                if (inPlay == true)
                {
                    spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y), Color.White);
                }

                
            }
        }
        #endregion

    }
}
