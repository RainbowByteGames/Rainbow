using Microsoft.Xna.Framework;

namespace RainbowByte.Rainbow
{
    public abstract class GameSystem : IGameSystem
    {
        public virtual int UpdatePriority { get; } = 0;
        public virtual IGameObject? Parent { get; set; }
        public abstract bool IsUpdatable { get; }
        public abstract bool IsDrawable { get; }

        public virtual bool PreDraw() { return true; }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void PostDraw() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void OnActivated(object? sender, EventArgs e) { }
        public virtual void OnDeactivated(object? sender, EventArgs e) { }
        public virtual void OnExiting(object? sender, EventArgs e) { }
    }
}
