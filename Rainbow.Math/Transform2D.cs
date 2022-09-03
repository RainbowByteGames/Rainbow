using Microsoft.Xna.Framework;

namespace Rainbow.Math
{
    /// <summary>
    ///     A structure containing 2D position, scale, and rotation.
    /// </summary>
    public struct Transform2D
    {
        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        ///     Gets or sets the scale.
        /// </summary>
        public Vector2 Scale { get; set; }
        /// <summary>
        ///     Gets or sets the rotation.
        /// </summary>
        public float Rotation { get; set; }
    }
}