using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.States
{
    public class EndGameState : State
    {
        Texture2D _endGameScreen;
        SpriteFont _spriteFont;

        public EndGameState()
        {
            StateIndex = 2;
        }
        public override void LoadContent()
        {
            _endGameScreen = Content.Load<Texture2D>("Assets/Pong_game_end");
            _spriteFont = Content.Load<SpriteFont>("Arial");
        }

        public override int Update(GameTime gameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();

            if (newKeyboardState.IsKeyDown(Keys.Space) /*&& StateManager.KeyboardState.IsKeyUp(Keys.Space) */)
            {
                
                return 0;
            }

            StateManager.KeyboardState = newKeyboardState;

            return 2;
            
        }

        public override void Draw(GameTime gameTime)
        {

            string _endGameText = "< Thank you for playing! Press <Space> to return to the main menu >";
            Vector2 _endGameSpace = _spriteFont.MeasureString(_endGameText);

            spriteBatch.Begin();

            spriteBatch.Draw(_endGameScreen, new Vector2(400 - (_endGameScreen.Width / 2), 240 - (_endGameScreen.Height / 2)), Color.White);

            spriteBatch.DrawString(_spriteFont, _endGameText, new Vector2(400 - (_endGameSpace.X / 2), 430), Color.White);

            spriteBatch.End();
            
        }
    }
}
