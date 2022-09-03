using Microsoft.Xna.Framework;
using Rainbow.Math;

namespace Rainbow.Physics
{
    /// <summary>
    ///     A circle collider.
    /// </summary>
    public class CircleCollider : ICollider2D
    {
        public KineticBody2D? Body { get; set; }
        /// <summary>
        ///     Gets or sets the center of the circle.
        /// </summary>
        public Vector2 Center => Body?.Position ?? Vector2.Zero;
        /// <summary>
        ///     Gets or sets the radius of the circle.
        /// </summary>
        public float Radius { get; set; }
        /// <summary>
        ///     Gets the bounds of this collider.
        /// </summary>
        public RectangleF Bounds => new RectangleF(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);

        public bool Intersects(ICollider2D other, bool throwback)
        {
            if (Body == null || other.Body == null) throw ICollider2DExt.NullBody();

            if (other is CircleCollider circle)
            {
                float dx = Center.X - circle.Center.X;
                float dy = Center.Y - circle.Center.Y;
                float dr = Radius + circle.Radius;

                return dx * dx + dy * dy < dr * dr;
            }
            else if (other is AABBCollider)
            {
                Vector2 closest = new Vector2(Center.X, Center.Y);
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

                float dx = closest.X - Center.X;
                float dy = closest.Y - Center.Y;
                return dx * dx + dy * dy < Radius * Radius;
            }
            else if (!throwback)
            {
                return other.Intersects(this, true);
            }
            throw ICollider2DExt.NotImplemented(other);
        }

        bool ICollider2D.Intersects(ICollider2D other, bool throwback)
        {
            throw new NotImplementedException();
        }
    }
}
