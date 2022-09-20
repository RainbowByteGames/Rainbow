using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    public abstract class GameObject : IGameObject
    {
        public IGameObject? Parent { get; set; }
        public abstract bool IsUpdatable { get; }
        public abstract bool IsDrawable { get; }

        public virtual void Draw(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime) { }
    }
}
