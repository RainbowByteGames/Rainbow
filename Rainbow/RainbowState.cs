using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HappiiDreamer.Rainbow.State
{
    public abstract class RainbowState : GameState
    {
        public RainbowGame Rainbow { get; }
        public SpriteBatch? SpriteBatch => Rainbow.SpriteBatch;
        /// <summary>
        ///     Gets a list of systems.
        /// </summary>
        public List<IGameSystem> Systems { get; } = new List<IGameSystem>();

        public RainbowState(StateManager states, int id) : base(states, id)
        {
            Rainbow = (RainbowGame) Game;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IGameSystem system in Systems)
            {
                if (system.IsUpdatable) system.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (IGameSystem system in Systems)
            {
                if (system.IsDrawable) system.Update(gameTime);
            }
        }
    }
}
