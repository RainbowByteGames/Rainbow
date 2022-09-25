using Microsoft.Xna.Framework;

namespace RainbowByte.Rainbow.Physics
{
    /// <summary>
    ///     A circle collider.
    /// </summary>
    public class CircleCollider : ICollider2D
    {
        /// <summary>
        ///     Gets the parent for this collider.
        /// </summary>
        public Collidable Parent { get; }
        /// <summary>
        ///     Gets or sets the radius of the circle.
        /// </summary>
        public float Radius { get; set; }
        /// <summary>
        ///     Gets the bounds of this collider.
        /// </summary>
        public RectangleF Bounds => new RectangleF(Parent.Position.X - Radius, Parent.Position.Y - Radius, Radius * 2, Radius * 2);

        public CircleCollider(Collidable parent)
        {
            Parent = parent;
        }

        public bool Intersects(ICollider2D other, bool throwback)
        {
            if (other is CircleCollider circle)
            {
                float dx = Parent.Position.X - circle.Parent.Position.X;
                float dy = Parent.Position.Y - circle.Parent.Position.Y;
                float dr = Radius + circle.Radius;

                return dx * dx + dy * dy < dr * dr;
            }
            else if (other is AABBCollider)
            {
                Vector2 closest = Parent.Position;
                if (closest.X < other.Bounds.Left)
                {
                    closest.X = other.Bounds.Left;
                }
                else if (closest.X > other.Bounds.Right)
                {
                    closest.X = other.Bounds.Right;
                }

                if (closest.Y < other.Bounds.Top)
                {
                    closest.Y = other.Bounds.Top;
                }
                else if (closest.Y > other.Bounds.Bottom)
                {
                    closest.Y = other.Bounds.Bottom;
                }

                float dx = closest.X - Parent.Position.X;
                float dy = closest.Y - Parent.Position.Y;
                return dx * dx + dy * dy < Radius * Radius;
            }
            else if (!throwback)
            {
                return other.Intersects(this, true);
            }
            throw new FellThroughCollisionException(this, other);
        }
    }
}
