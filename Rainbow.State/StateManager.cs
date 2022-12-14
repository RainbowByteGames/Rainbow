using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HappiiDreamer.Rainbow.State
{
    /// <summary>
    ///     Manages multiple game states.
    /// </summary>
    public class StateManager : IGameState
    {
        private List<Type> States { get; } = new List<Type>();

        /// <summary>
        ///     Gets the game which owns this state manager.
        /// </summary>
        public Game Game { get; }
        /// <summary>
        ///     Gets the current game state.
        /// </summary>
        public GameState? CurrentState { get; private set; }
        /// <summary>
        ///     Gets whether the states have already loaded their
        ///     content.
        /// </summary>
        public bool IsContentLoaded { get; private set; }

        public StateManager(Game game)
        {
            this.Game = game;
        }

        /// <summary>
        ///     Adds a new state. If content has already
        ///     been loaded, use at your own risk.
        /// </summary>
        /// <typeparam name="T">The type of state.</typeparam>
        /// <returns>The id of the added state.</returns>
        public int AddState<T>() where T : GameState
        {
            States.Add(typeof(T));
            return States.Count - 1;
        }
        /// <summary>
        ///     Leaves the current state and enters the specified
        ///     state.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="RainbowStateException"></exception>
        public void Goto(int id)
        {
            GameState? from = CurrentState;
            GameState to = CreateState(id);

            from?.Leave(to);
            CurrentState = to;
            to.Enter(from);
        }
        private GameState CreateState(int id)
        {
            GameState? state = (GameState?) Activator.CreateInstance(States[id], this, id);
            if (state == null)
            {
                throw new RainbowStateException($"Failed to create state: {id}", null);
            }
            return state;
        }

        /// <summary>
        ///     Loads content for all states.
        /// </summary>
        /// <param name="content"></param>
        /// <exception cref="RainbowStateException"></exception>
        public void LoadContent(ContentManager content)
        {
            for (int i = 0; i < States.Count; i++)
            {
                CreateState(i).LoadContent(content);
            }
            IsContentLoaded = true;
        }
        /// <summary>
        ///     Unloads content on all states. Does not call
        ///     content.Unload().
        /// </summary>
        /// <param name="content"></param>
        /// <exception cref="RainbowStateException"></exception>
        public void UnloadContent(ContentManager content)
        {
            for (int i = 0; i < States.Count; i++)
            {
                CreateState(i).UnloadContent(content);
            }
            IsContentLoaded = false;
        }

        /// <summary>
        ///     Calls Update on the current state.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            CurrentState?.Update(gameTime);
        }

        /// <summary>
        ///     Calls BeginDraw on the current state.
        /// </summary>
        /// <returns></returns>
        public bool BeginDraw()
        {
            return CurrentState?.BeginDraw() ?? false;
        }
        /// <summary>
        ///     Calls Draw on the current state.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw(GameTime gameTime)
        {
            CurrentState?.Draw(gameTime);
        }
        /// <summary>
        ///     Calls EndDraw on the current state.
        /// </summary>
        public void EndDraw()
        {
            CurrentState?.EndDraw();
        }

        /// <summary>
        ///     Calls OnActivated on the current state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActivated(object? sender, EventArgs e)
        {
            CurrentState?.OnActivated(sender, e);
        }
        /// <summary>
        ///     Calls OnDeactivated on the current state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDeactivated(object? sender, EventArgs e)
        {
            CurrentState?.OnDeactivated(sender, e);
        }
    }
}
