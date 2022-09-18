using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    public abstract class GameSystem : IGameSystem
    {
        public Game Game { get; }
        public abstract bool IsUpdatable { get; }
        public abstract bool IsDrawable { get; }

        public GameSystem(Game game)
        {
            Game = game;
        }

        public virtual bool BeginDraw() { return true; }
        public virtual void Draw(GameTime gameTime) { }
        public virtual void EndDraw() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void OnActivated(object? sender, EventArgs e) { }
        public virtual void OnDeactivated(object? sender, EventArgs e) { }
        public virtual void OnExiting(object? sender, EventArgs e) { }
    }
}
