using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Physics
{
    /// <summary>
    ///     An interface which describes a 2D collider.
    /// </summary>
    public interface ICollider2D
    {
        /// <summary>
        ///     Gets the parent of this collider.
        /// </summary>
        public KineticBody2D? Body { get; internal set; }
        /// <summary>
        ///     Gets or sets the origin.
        /// </summary>
        public Vector2 Origin { get; set; }
        /// <summary>
        ///     Gets the bounds of this collider.
        /// </summary>
        public RectangleF Bounds { get; }
        /// <summary>
        ///     Checks whether this collider intersects the other collider.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="throwback">Whether this method is thrown back from the other collider</param>
        /// <returns></returns>
        public bool Intersects(ICollider2D other, bool throwback);
    }
}