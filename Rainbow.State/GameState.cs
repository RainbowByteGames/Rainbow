using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rainbow.State
{
    /// <summary>
    ///     A class which represents a game state. Implementations of
    ///     this class should not have a constructor. Use GameState.Load
    ///     instead.
    /// </summary>
    public abstract class GameState : IGameState
    {
        /// <summary>
        ///     Gets or sets the state manager for this state.
        /// </summary>
        public StateManager Manager { get; }
        /// <summary>
        ///     Gets or sets the ID for this state in the
        ///     state manager.
        /// </summary>
        public int ID { get; }

        public GameState(StateManager manager, int id)
        {
            this.Manager = manager;
            this.ID = id;
        }

        /// <summary>
        ///     Loads the content that is needed for the
        ///     state. This is only called once.
        /// </summary>
        /// <param name="content"></param>
        public virtual void LoadContent(ContentManager content) { }
        /// <summary>
        ///     Unloads the content which was loaded
        ///     previously. Content.Unload should not be
        ///     called here.
        /// </summary>
        /// <param name="content"></param>
        public virtual void UnloadContent(ContentManager content) { }

        /// <summary>
        ///     This is called when the state manager
        ///     enters the state. The instance will be a
        ///     fresh instance.
        /// </summary>
        public abstract void Enter();
        /// <summary>
        ///     This is called when the state manager
        ///     leaves the state. The instance is destoried
        ///     afterwords.
        /// </summary>
        public virtual void Leave() { }

        /// <summary>
        ///     Updates the game state.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime) { }
        /// <summary>
        ///     Updates the game on a fixed time step, set by the RainbowGame.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void FixedUpdate(GameTime gameTime) { }

        /// <summary>
        ///     Draws the game state.
        /// </summary>
        /// <param name="batch">Global sprite batch.</param>
        /// <param name="gameTime"></param>
        public virtual void Draw(GameTime gameTime) { }
        /// <summary>
        ///     Called right before Microsoft.Xna.Framework.Game.Draw(Microsoft.Xna.Framework.GameTime)
        ///     is normally called. Can return false to let the game loop not call 
        ///     Microsoft.Xna.Framework.Game.Draw(Microsoft.Xna.Framework.GameTime).
        /// </summary>
        /// <returns></returns>
        public virtual bool BeginDraw() { return true; }
        /// <summary>
        ///     Called right after Microsoft.Xna.Framework.Game.Draw(Microsoft.Xna.Framework.GameTime)
        ///     is normally called.
        /// </summary>
        public virtual void EndDraw() { }

        /// <summary>
        ///     Called when a the app gains focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnActivated(object? sender, EventArgs args) { }
        /// <summary>
        ///     Called whne the app loses focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnDeactivated(object? sender, EventArgs args) { }
    }
}
