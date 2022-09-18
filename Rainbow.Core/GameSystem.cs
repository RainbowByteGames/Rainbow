using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    public abstract class GameSystem : GameObject
    {
        public GameSystem(Game game) : base(game) { }

        public virtual bool BeginDraw() { return true; }
        public virtual void EndDraw() { }

        public virtual void OnActivated(object? sender, EventArgs e) { }
        public virtual void OnDeactivated(object? sender, EventArgs e) { }
        public virtual void OnExiting(object? sender, EventArgs e) { }
    }
}
