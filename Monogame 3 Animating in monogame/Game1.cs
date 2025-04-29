using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_3_Animating_in_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Vector2 tribbleGreySpeed, tribbleCreamSpeed;
        Vector2 tribbleBrownSpeed, tribbleOrangeSpeed;

        Texture2D tribbleGreyTexture, tribbleCreamTexture;
        Texture2D tribbleBrownTexture, tribbleOrangeTexture;
        Texture2D spacethingTexture;

        Rectangle tribbleGreyRect, tribbleCreamRect;
        Rectangle tribbleBrownRect, tribbleOrangeRect;
        Rectangle spacethingRect;

        Rectangle window;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0,0,800,600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleGreyRect = new Rectangle(300,100,100,100);

            tribbleGreySpeed = new Vector2(2,-3);

            tribbleCreamRect = new Rectangle(150,250,100,100);
            
            tribbleCreamSpeed = new Vector2(2,0);

            tribbleBrownRect = new Rectangle(450, 100, 100, 100);
            
            tribbleBrownSpeed = new Vector2(0,2);

            tribbleOrangeRect = new Rectangle(600,100,100,100);

            tribbleOrangeSpeed = new Vector2(2,-1);

            spacethingRect = new Rectangle(0,0,800,600);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");

            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");

            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");

            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            spacethingTexture = Content.Load<Texture2D>("spacething");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            if (tribbleGreyRect.Right >= window.Width || tribbleGreyRect.Left <= 0)
            {
                tribbleGreySpeed.X *= -1;
            }
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Bottom >= window.Height || tribbleGreyRect.Top <= 0)
            {
                tribbleGreySpeed.Y *= -1;
            }

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
             if (tribbleCreamRect.Left > window.Width)
            {
                tribbleCreamRect.X = -100;
            }
            if (tribbleCreamRect.Right < 0)
            {
                tribbleCreamRect.X = 800;
            }

            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleBrownRect.Top > window.Height)
            {
                tribbleBrownRect.Y = -100;
            }
            if (tribbleBrownRect.Bottom < 0)
            {
                tribbleBrownRect.Y = 600;
            }

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRect.Right >= window.Width || tribbleOrangeRect.Left <= 0)
            {
                tribbleOrangeSpeed.X *= -1;
            }
            if (tribbleOrangeRect.Top > window.Height)
            {
                tribbleOrangeRect.Y = -100;
            } 
            if (tribbleOrangeRect.Bottom <= 0)
            {
                tribbleOrangeRect.Y = 600;
            }

            if (tribbleGreyRect.Intersects(tribbleCreamRect))
            {
                tribbleCreamSpeed.X *= -1;
                tribbleGreySpeed.X *= -1;
                tribbleGreySpeed.Y *= -1;
            }
            if (tribbleBrownRect.Intersects(tribbleCreamRect))
            {
                tribbleBrownSpeed.Y *= -1;
                tribbleCreamSpeed.X *= -1;
            }
            if (tribbleBrownRect.Intersects(tribbleGreyRect))
            {
                tribbleGreySpeed.Y *= -1;
                tribbleBrownSpeed.Y *= -1;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(spacethingTexture, spacethingRect ,Color.White);

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);

            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);

            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
