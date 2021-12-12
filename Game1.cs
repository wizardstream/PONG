using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    public class Game1 : Game
    {
        Texture2D PlayerTexture;
        Texture2D LoadTexture;
        Song Song;
        Vector2 PlayerPos;
        float ballSpeed;
        Vector2 LoadPosition;

        private string Scene = "Play";

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Enemy _enemy;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _enemy = new Enemy();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            PlayerPos = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;
            LoadPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _enemy.SetContent(Content.Load<Texture2D>("fish"));

            // TODO: use this.Content to load your game content here
            PlayerTexture = Content.Load<Texture2D>("crocim");
            LoadTexture = Content.Load<Texture2D>("loading_desktop_by_brianmccumber-d41z4h6");

            Song = Content.Load<Song>("underwater");
            MediaPlayer.Play(Song);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                IsMouseVisible = true;
            }
                

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                PlayerPos.Y -= ballSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                PlayerPos.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
                

            if (kstate.IsKeyDown(Keys.A))
            {
                PlayerPos.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
                

            if (kstate.IsKeyDown(Keys.D))
            {
                PlayerPos.X += ballSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (PlayerPos.X > _graphics.PreferredBackBufferWidth - PlayerTexture.Width / 2)
                PlayerPos.X = _graphics.PreferredBackBufferWidth - PlayerTexture.Width / 2;
            else if (PlayerPos.X < PlayerTexture.Width / 2)
                PlayerPos.X = PlayerTexture.Width / 2;

            if (PlayerPos.Y > _graphics.PreferredBackBufferHeight - PlayerTexture.Height / 2)
                PlayerPos.Y = _graphics.PreferredBackBufferHeight - PlayerTexture.Height / 2;
                
            else if (PlayerPos.Y < PlayerTexture.Height / 2)
                PlayerPos.Y = PlayerTexture.Height / 2;


            _enemy.Update(PlayerPos);
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
                    PlayerPos,
                    null,
                    Color.White,
                    0f,
                    new Vector2(PlayerTexture.Width / 2, PlayerTexture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f);
                _enemy.Draw(_spriteBatch);
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
