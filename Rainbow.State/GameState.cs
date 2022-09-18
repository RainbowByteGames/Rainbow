using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HappiiDreamer.Rainbow.State
{
    /// <summary>
    ///     A class which represents a game state and attempts to mirror
    ///     the main Game class.
    /// </summary>
    public abstract class GameState : IGameState
    {
        /// <summary>
        ///     Gets the game this state belongs to.
        /// </summary>
        public Game Game => States.Game;
        public IGameObject? Parent => null;
        public bool IsUpdatable => true;
        public bool IsDrawable => true;

        /// <summary>
        ///     Gets whether the game is active.
        /// </summary>
        public bool IsActive => Game.IsActive;
        /// <summary>
        ///     Gets the game's content manager.
        /// </summary>
        public ContentManager Content => Game.Content;
        /// <summary>
        ///     Gets the game's graphics device.
        /// </summary>
        public GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
        /// <summary>
        ///     Gets the game's window.
        /// </summary>
        public GameWindow Window => Game.Window;

        /// <summary>
        ///     Gets or sets the state manager for this state.
        /// </summary>
        public StateManager States { get; }
        /// <summary>
        ///     Gets or sets the ID for this state in the
        ///     state manager.
        /// </summary>
        public int ID { get; }

        public GameState(StateManager states, int id)
        {
            States = states;
            ID = id;
        }

        /// <summary>
        ///     Exits the game.
        /// </summary>
        public void Exit() => Game.Exit();

        /// <summary>
        ///     Loads the content that is needed for the
        ///     state. This is only called once.
        /// </summary>
        /// <param name="content"></param>
        public virtual void LoadContent() { }
        /// <summary>
        ///     Unloads the content which was loaded
        ///     previously. Content.Unload should not be
        ///     called here.
        /// </summary>
        /// <param name="content"></param>
        public virtual void UnloadContent() { }

        /// <summary>
        ///     This is called when the state manager
        ///     enters the state. The instance will be a
        ///     fresh instance.
        /// </summary>
        public abstract void Enter(GameState? from);
        /// <summary>
        ///     This is called when the state manager
        ///     leaves the state. The instance is destoried
        ///     afterwords.
        /// </summary>
        public virtual void Leave(GameState? to) { }

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
        ///     Called when the app gains focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnActivated(object? sender, EventArgs args) { }
        /// <summary>
        ///     Called when the app loses focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnDeactivated(object? sender, EventArgs args) { }
        /// <summary>
        ///     Called when the app is exiting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnExiting(object? sender, EventArgs args) { }
    }
}
