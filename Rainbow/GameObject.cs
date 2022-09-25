﻿using Microsoft.Xna.Framework;

namespace RainbowByte.Rainbow
{
    public abstract class GameObject : IGameObject
    {
        public IGameObject? Parent { get; set; }
        public abstract bool IsUpdatable { get; }
        public virtual int UpdatePriority { get; } = 0;
        public abstract bool IsDrawable { get; }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
    }
}
