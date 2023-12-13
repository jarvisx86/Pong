using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Models;

namespace Pong.Sprites
{
    public class Sprite
    {
        #region Fields
        protected Vector2 _position;
        #endregion

        #region Properties
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position 
        {
            get { return _position; }
            set { _position = value; } 
        }

        public float PositionY 
        { 
            get => _position.Y;
            set 
            {
                _position.Y = value;
            }
        }

        public Vector2 Velocity;

        public float Speed = 1f;
        public Texture2D Texture { get; set; }
        
        public Input Input;   
        #endregion

        #region Constructors

        public Sprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Width = texture.Width;
            Height = texture.Height;
            Speed = 7f;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
            else
            {
                throw new Exception("Texture is null");
            }

        }

        public void Move()
        {
            Position += Velocity;

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
                
                if (Position.Y <= 10)
                {
                    _position.Y = 10;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
                
                if (Position.Y >= 470 - Height)
                {
                    _position.Y = 470 - Height;
                }
            }
            else
            {
                Velocity.Y = 0;
            }

        }
        #endregion

    }
}
