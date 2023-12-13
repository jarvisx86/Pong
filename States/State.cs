using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.States
{
    public abstract class State
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        
        public int StateIndex { get; set; }

        public ContentManager Content { get; set; }

        public abstract void LoadContent();

        public abstract int Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);

    }
}
