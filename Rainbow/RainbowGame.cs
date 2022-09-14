using HappiiDreamer.Rainbow.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HappiiDreamer.Rainbow
{
    public abstract class RainbowGame : Game
    {
        /// <summary>
        ///     Gets the state manager.
        /// </summary>
        public StateManager States { get; }
        /// <summary>
        ///     Gets the graphics device manager.
        /// </summary>
        public GraphicsDeviceManager Graphics { get; }
        /// <summary>
        ///     Gets the global sprite batch.
        /// </summary>
        public SpriteBatch? SpriteBatch { get; private set; }
        /// <summary>
        ///     Gets the fixed step timer.
        /// </summary>
        public FixedStepTimer FixedStepTimer { get; } = new FixedStepTimer();

        public RainbowGame()
        {
            States = new StateManager(this);
            Graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Loads the states' content.
            States.LoadContent();
            States.Goto(0);
        }
        protected override void UnloadContent()
        {
            // Unload the states' content.
            States.UnloadContent();
            // Unload content
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            // Call update.
            States.CurrentState?.Update(gameTime);

            // Call fixed update
            FixedStepTimer.Ellapse(gameTime.ElapsedGameTime);
            GameTime fixedGameTime = new GameTime(gameTime.TotalGameTime, FixedStepTimer.TimeStep);
            while (FixedStepTimer.TryStep(out _))
            {
                States.CurrentState?.FixedUpdate(fixedGameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            States.CurrentState?.Draw(gameTime);
            base.Draw(gameTime);
        }
        protected override bool BeginDraw()
        {
            return States.CurrentState?.BeginDraw() ?? true;
        }
        protected override void EndDraw()
        {
            States.CurrentState?.EndDraw();
            base.EndDraw();
        }

        protected override void OnActivated(object? sender, EventArgs args)
        {
            States.CurrentState?.OnActivated(sender, args);
            base.OnActivated(sender, args);
        }
        protected override void OnDeactivated(object? sender, EventArgs args)
        {
            States.CurrentState?.OnDeactivated(sender, args);
            base.OnActivated(sender, args);
        }
        protected override void OnExiting(object? sender, EventArgs args)
        {
            States.CurrentState?.OnExiting(sender, args);
            base.OnExiting(sender, args);
        }
    }
}
