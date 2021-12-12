using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        Texture2D PlayerTexture;
        Texture2D LoadTexture;
        Vector2 ballPosition;
        float ballSpeed;
        Vector2 LoadPosition;

        private string Scene = "Play";

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;
            LoadPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            PlayerTexture = Content.Load<Texture2D>("crocim");
            LoadTexture = Content.Load<Texture2D>("loading_desktop_by_brianmccumber-d41z4h6");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                ballPosition.Y -= ballSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
                

            if (kstate.IsKeyDown(Keys.A))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
                

            if (kstate.IsKeyDown(Keys.D))
            {
                ballPosition.X += ballSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (ballPosition.X > _graphics.PreferredBackBufferWidth - PlayerTexture.Width / 2)
                ballPosition.X = _graphics.PreferredBackBufferWidth - PlayerTexture.Width / 2;
            else if (ballPosition.X < PlayerTexture.Width / 2)
                ballPosition.X = PlayerTexture.Width / 2;

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - PlayerTexture.Height / 2)
                ballPosition.Y = _graphics.PreferredBackBufferHeight - PlayerTexture.Height / 2;
                
            else if (ballPosition.Y < PlayerTexture.Height / 2)
                ballPosition.Y = PlayerTexture.Height / 2;
                


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Scene == "Play")
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            else if (Scene == "Loading1")
            {
                GraphicsDevice.Clear(Color.Black);
            }
            

            // TODO: Add your drawing code here
            if (Scene == "Play")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(
                    PlayerTexture,
                    ballPosition,
                    null,
                    Color.White,
                    0f,
                    new Vector2(PlayerTexture.Width / 2, PlayerTexture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f);
                _spriteBatch.End();
            }
            else if (Scene == "Loading1")
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(
                    LoadTexture,
                    LoadPosition,
                    null,
                    Color.White,
                    0f,
                    new Vector2(LoadTexture.Width / 2, LoadTexture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f);

                _spriteBatch.End();
            }
            

            base.Draw(gameTime);
        }
    }
}
