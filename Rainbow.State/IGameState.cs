using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.State
{
    /// <summary>
    ///     An interface containing all relavent methods for a game state.
    /// </summary>
    public interface IGameState
    {
        public Game Game { get; }
        
        public void LoadContent() { }
        public void UnloadContent() { }

        public void Update(GameTime gameTime);

        public bool BeginDraw();
        public void Draw(GameTime gameTime);
        public void EndDraw();

        public void OnActivated(object? sender, EventArgs e);
        public void OnDeactivated(object? sender, EventArgs e);
        public void OnExiting(object? sender, EventArgs e);
    }
}
