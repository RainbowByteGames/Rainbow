using HappiiDreamer.Rainbow.Math;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Physics
{
    /// <summary>
    ///     An Axis-Aligned Bounding Box collider.
    /// </summary>
    public class AABBCollider : ICollider2D
    {
        /// <summary>
        ///     Gets the body for this collider.
        /// </summary>
        public KineticBody2D? Body { get; set; }
        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        ///     Gets or sets the bounds of the collider.
        /// </summary>
        public RectangleF Bounds => new RectangleF(Body?.Position.X ?? 0, Body?.Position.Y ?? 0, Width, Height);

        public bool Intersects(ICollider2D other, bool throwback)
        {
            if (Body == null || other.Body == null) throw ICollider2DExt.NullBody();
            if (other is AABBCollider)
            {
                return Bounds.Intersects(other.Bounds);
            }
            else if (!throwback)
            {
                return other.Intersects(this, true);
            }
            throw ICollider2DExt.NotImplemented(other);
        }
    }
}
