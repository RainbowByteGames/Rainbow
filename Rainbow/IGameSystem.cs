using Microsoft.Xna.Framework;

namespace RainbowByte.Engine
{
    /// <summary>
    ///     An interface containing all relavent methods for a high level game system.
    /// </summary>
    public interface IGameSystem : IGameObject
    {
        /// <summary>
        ///     Called before the system is drawn. Returning false will skip the draw.
        /// </summary>
        /// <returns></returns>
        public bool PreDraw();
        /// <summary>
        ///     Called after the system is drawn.
        /// </summary>
        public void PostDraw();

        public void OnActivated(object? sender, EventArgs e);
        public void OnDeactivated(object? sender, EventArgs e);
        public void OnExiting(object? sender, EventArgs e);
    }
}
