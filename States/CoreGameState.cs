using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Pong.Models;
using Pong.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.States
{
    public class CoreGameState : State
    {

        List<Sprite> sprites;
        Texture2D gameBorder;
        Ball ball;

        public CoreGameState()
        {
            StateIndex = 1;
            
        }

        public override void LoadContent()
        {
            sprites = new List<Sprite>()
            {

                new Sprite(Content.Load<Texture2D>("Assets/paddle1"), new Vector2(50, 240 - 16))
                {
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                    }
                },
                new Sprite(Content.Load<Texture2D>("Assets/paddle2"), new Vector2(750 - 16, 240 - 16))
                {
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                    }
                },

            };

            gameBorder = Content.Load<Texture2D>("Assets/Border-export");

            ball = new Ball(Content.Load<Texture2D>("Assets/ball"), new Vector2(400, 240))
            {
                ScoreFont = Content.Load<SpriteFont>("Arial"),
            };
        }

        public override int Update(GameTime gameTime)
        {
            // TODO: Add your update logic here


            while (ball.ScorePlayer1 != 2 && ball.ScorePlayer2 != 2)
            {
                foreach (Sprite sprite in sprites)
                {
                    sprite.Move();
                    ball.Move(sprite);
                }

                return 1;
            }
            
            ball.Position = new Vector2(400, 240);
            ball.ScorePlayer1 = 0;
            ball.ScorePlayer2 = 0;

            ball.SpeedX = 1.5f;
            ball.SpeedY = 1.5f;

            foreach (Sprite sprite in sprites)
            {
                sprite.PositionY = 240 - (sprite.Height / 2);
            }


            


            

            return 2;

            /*if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //f ((ball.ScorePlayer1 - ball.ScorePlayer2 > 2) || (ball.ScorePlayer2 - ball.ScorePlayer1 > 2))
                //{

                    return 2;

                //}

                //return 1;

                
            }
            else
            {
                return 1;
            }*/
            
                
            
        }
  

        public override void Draw(GameTime gameTime)
        {
            // vars for displaying player scores in the core game loop
            string scorePlayer1 = "Score: " + ball.ScorePlayer1.ToString("0000");
            string scorePlayer2 = "Score: " + ball.ScorePlayer2.ToString("0000");
            Vector2 player1DisplayScore = ball.ScoreFont.MeasureString(scorePlayer1);
            Vector2 player2DisplayScore = ball.ScoreFont.MeasureString(scorePlayer2);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(gameBorder, new Vector2(0, 0), Color.White); // Draw game window border

            spriteBatch.DrawString(ball.ScoreFont, scorePlayer1, new Vector2(20, 460 - player1DisplayScore.Y), Color.White); // Draw score Player 1

            spriteBatch.DrawString(ball.ScoreFont, scorePlayer2, new Vector2(780 - player2DisplayScore.X, 460 - player2DisplayScore.Y), Color.White); // Draw score player 2

           
            ball.Draw(spriteBatch); // Draw ball

            foreach (Sprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        /* private void Launch()
        {
            throw new NotImplementedException("Lauch method not implemented yet");
        } */
    }
}
