using HappiiDreamer.Rainbow.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HappiiDreamer.Rainbow.State
{
    public abstract class RainbowState : GameState
    {
        /// <summary>
        ///     Gets the virtual camera.
        /// </summary>
        public Camera2D Camera { get; } = new Camera2D();
        /// <summary>
        ///     Gets a list of systems.
        /// </summary>
        public List<IGameSystem> Systems { get; } = new List<IGameSystem>();

        public RainbowState(StateManager states, int id) : base(states, id)
        {
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
                if (system.IsDrawable && system.PreDraw())
                {
                    system.Draw(gameTime);
                    system.PostDraw();
                }
            }
        }
    }
}
