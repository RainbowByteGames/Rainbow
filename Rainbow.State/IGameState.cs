using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Rainbow.State
{
    /// <summary>
    ///     An interface containing all relavent methods for a game state.
    /// </summary>
    public interface IGameState
    {
        public void LoadContent(ContentManager content) { }
        public void UnloadContent(ContentManager content) { }

        public void Update(GameTime gameTime);

        public bool BeginDraw();
        public void Draw(GameTime gameTime);
        public void EndDraw();

        public void OnActivated(object? sender, EventArgs e);
        public void OnDeactivated(object? sender, EventArgs e);
    }
}
