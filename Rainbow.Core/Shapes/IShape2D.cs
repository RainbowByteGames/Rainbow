using HappiiDreamer.Rainbow.Math;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Shapes
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
    /// <summary>
    ///     A class which adds helper methods to IShape2D.
    /// </summary>
    public static class IShape2DExt
    {
        /// <summary>
        ///     Checks whether this shape contains a point.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static bool Contains(this IShape2D shape, Vector2 pt)
        {
            return shape.Contains(pt.X, pt.Y);
        }
        /// <summary>
        ///     Checks whether this shape contains a point.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static bool Contains(this IShape2D shape, Point pt)
        {
            return shape.Contains(pt.X, pt.Y);
        }
        /// <summary>
        ///     Checks whether this shape intersects another.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool Intersects(this IShape2D shape, IShape2D other)
        {
            return shape.Intersects(other, false);
        }

        /// <summary>
        ///     Offsets this rectangle.
        /// </summary>
        /// <param name="offset"></param>
        public static void Offset(this IShape2D shape, Vector2 offset)
        {
            shape.Location += offset;
        }
        /// <summary>
        ///     Offsets this rectangle.
        /// </summary>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        public static void Offset(this IShape2D shape, float offsetX, float offsetY) => Offset(shape, new Vector2(offsetX, offsetY));
        /// <summary>
        ///     Offsets this rectangle.
        /// </summary>
        /// <param name="offset"></param>
        public static void Offset(this IShape2D shape, Point offset) => Offset(shape, offset.X, offset.Y);
    }
}
