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
    public class StartMenuState : State
    {

        StartMenu _startMenu;
        SpriteFont _spriteFont;
        public StartMenuState()
        {
            StateIndex = 0;
        }

        public override void LoadContent()
        {
            _startMenu = new StartMenu()
            {
                StartScreenLogo = Content.Load<Texture2D>("Assets/Pong_game_start"),
                StartButton = Content.Load<Texture2D>("Assets/Start_button"),
            };

            _spriteFont = Content.Load<SpriteFont>("Arial");
        }

        public override int Update(GameTime gameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();

            if (newKeyboardState.IsKeyDown(Keys.Enter) && StateManager.KeyboardState.IsKeyUp(Keys.Enter))
            {

                if (StateManager.KeyboardState.IsKeyUp(Keys.Enter))
                    Console.WriteLine("True");

                return 1;
            }

            StateManager.KeyboardState = newKeyboardState;

            return 0;

        }

        public override void Draw(GameTime gameTime)
        {
            string _startText = "< Press <Enter> to begin! >";
            Vector2 _startTextSpace = _spriteFont.MeasureString(_startText);
            
            spriteBatch.Begin();

            spriteBatch.Draw(_startMenu.StartScreenLogo, new Vector2(400 - (_startMenu.StartScreenLogo.Width / 2), 240 - (_startMenu.StartScreenLogo.Height / 2)), Color.White);

            spriteBatch.DrawString(_spriteFont, _startText, new Vector2(400 - (_startTextSpace.X / 2), 430), Color.White);

            spriteBatch.End();
        }
    }
}
