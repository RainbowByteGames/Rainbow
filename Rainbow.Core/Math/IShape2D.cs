using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Math
{
    public interface IShape2D
    {
        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        public Vector2 Location { get; set; }
        /// <summary>
        ///     Gets the bounds of the shape.
        /// </summary>
        public RectangleF Bounds { get; }

        /// <summary>
        ///     Checks whether this shape contains a point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contains(float x, float y);
        /// <summary>
        ///     Checks whether this shape intersects another.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="fallback">Whether this call is the result of other's fallback.</param>
        /// <exception cref="FellThroughIntersectionException"></exception>
        /// <returns></returns>
        public bool Intersects(IShape2D other, bool fallback);
    }
}
