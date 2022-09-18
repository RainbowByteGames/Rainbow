using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    public abstract class GameObject : IGameObject
    {
        public Game Game { get; }
        public abstract bool IsUpdatable { get; }
        public abstract bool IsDrawable { get; }

        public GameObject(Game game)
        {
            Game = game;
        }

        public virtual void Draw(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
    }
}
