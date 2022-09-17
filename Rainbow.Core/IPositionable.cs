using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    /// <summary>
    ///     A basic interface for holding a position.
    /// </summary>
    public interface IPositionable
    {
        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public Vector2 Position { get; set; }
    }
}
