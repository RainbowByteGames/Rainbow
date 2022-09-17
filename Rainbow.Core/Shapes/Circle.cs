using HappiiDreamer.Rainbow.Shapes;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Math
{
    public struct Circle : IShape2D
    {
        public Vector2 Location { get; set; }
        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        public float Radius { get; set; }

        public RectangleF Bounds => new RectangleF(Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);

        public bool Contains(float x, float y)
        {
            float dx = x - Location.X;
            float dy = y - Location.Y;
            return dx * dx + dy * dy <= Radius * Radius;
        }
        public bool Intersects(IShape2D other, bool fallback)
        {
            if (other is Circle circle)
            {
                float dx = Location.X - circle.Location.X;
                float dy = Location.Y - circle.Location.Y;
                float dr = Radius + circle.Radius;

                return dx * dx + dy * dy < dr * dr;
            }
            else if (other is RectangleF rect)
            {
                Vector2 closest = new Vector2(Location.X, Location.Y);
                if (closest.X < rect.Left)
                {
                    closest.X = rect.Left;
                }
                else if (closest.X > rect.Right)
                {
                    closest.X = rect.Right;
                }

                if (closest.Y < rect.Top)
                {
                    closest.Y = rect.Top;
                }
                else if (closest.Y > rect.Bottom)
                {
                    closest.Y = rect.Bottom;
                }

                return this.Contains(closest);
            }
            else if (!fallback)
            {
                return other.Intersects(this, true);
            }
            else
            {
                throw new FellThroughIntersectionException(this, other);
            }
        }
    }
}
