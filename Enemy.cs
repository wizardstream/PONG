using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    class Enemy
    {
        private Texture2D EnemyTexture;
        private Vector2 _pos;
        
       public Enemy()
        {   
        }

        public void SetContent(Texture2D enemy)
        {
            EnemyTexture = enemy;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(EnemyTexture, 
                _pos,
                null,
                Color.White,
                0f,
                new Vector2(EnemyTexture.Width / 2, EnemyTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
        }

        public void Update(Vector2 playerPos)
        {
            if (_pos.X < playerPos.X)
            {
                _pos.X = _pos.X + 1;
            }
            if (_pos.X > playerPos.X)
            {
                _pos.X = _pos.X - 1;
            }
            if (_pos.Y < playerPos.Y)
            {
                _pos.Y = _pos.Y + 1;
            }

            if (_pos.Y > playerPos.Y){

                _pos.Y = _pos.Y - 1;
            }
        }
    }
}
