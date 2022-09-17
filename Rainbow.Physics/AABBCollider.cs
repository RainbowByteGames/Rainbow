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
        public ICollidable Parent { get; }

        /// <summary>
        ///     Gets or sets the position offset.
        /// </summary>
        public Vector2 Origin { get; set; } = Vector2.Zero;
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
        public RectangleF Bounds => new RectangleF
        {
            X = Parent.Position.X - Origin.X * Width,
            Y = Parent.Position.Y - Origin.Y * Height,
            Width = Width,
            Height = Height
        };

        public AABBCollider(ICollidable parent)
        {
            Parent = parent;
        }

        public bool Intersects(ICollider2D other, bool throwback)
        {
            if (other is AABBCollider)
            {
                return Bounds.Intersects(other.Bounds);
            }
            else if (!throwback)
            {
                return other.Intersects(this, true);
            }
            throw new FellThroughCollisionException(this, other);
        }
    }
}
