using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;

namespace Rainbow.Math
{
    /// <summary>
    ///     The floating-point equivalent of Microsoft.Xna.Framework.Rectangle
    /// </summary>
    public struct RectangleF : IEquatable<RectangleF>, IEquatable<Rectangle>
    {
        public float X, Y, Width, Height;

        /// <summary>
        ///     Gets or sets the location of the rectangle.
        /// </summary>
        public Vector2 Location
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        /// <summary>
        ///     Gets or sets the size of the rectangle.
        /// </summary>
        public Vector2 Size
        {
            get => new Vector2(Width, Height);
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        /// <summary>
        ///     Gets the center of the rectangle.
        /// </summary>
        public Vector2 Center
        {
            get => new Vector2(X + Width / 2, Y + Height / 2);
        }
        /// <summary>
        ///     Gets the left-most side.
        /// </summary>
        public float Left
        {
            get => X;
        }
        /// <summary>
        ///     Gets the top-most side.
        /// </summary>
        public float Top
        {
            get => Y;
        }
        /// <summary>
        ///     Gets the right-most side.
        /// </summary>
        public float Right
        {
            get => X + Width;
        }
        /// <summary>
        ///     Gets the bottom-most side.
        /// </summary>
        public float Bottom
        {
            get => Y + Height;
        }

        /// <summary>
        ///     Checks whether this rectangle contains a point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contains(float x, float y)
        {
            return
                x >= Left && x <= Right &&
                y >= Top && y <= Bottom;
        }
        /// <summary>
        ///     Checks whether this rectangle contains a point.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Contains(Vector2 pt) => Contains(pt.X, pt.Y);
        /// <summary>
        ///     Checks whether this rectangle contains a point.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Contains(Point pt) => Contains(pt.X, pt.Y);

        /// <summary>
        ///     Destructs a rectangle into its components.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Destruct(out float x, out float y, out float width, out float height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }
        /// <summary>
        ///     Inflates the rectangle in both directions.
        /// </summary>
        /// <param name="horizontalAmount"></param>
        /// <param name="verticalAmount"></param>
        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            X -= horizontalAmount / 2;
            Y -= verticalAmount / 2;
            Width += horizontalAmount / 2;
            Height += verticalAmount / 2;
        }
        /// <summary>
        ///     Checks whether two rectangles intersect.
        /// </summary>
        /// <param name="other"></param>
        public bool Intersects(RectangleF other)
        {
            return
                Left <= other.Right && Right >= other.Left &&
                Top <= other.Bottom && Bottom >= other.Top;
        }
        /// <summary>
        ///     Offsets this rectangle.
        /// </summary>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        public void Offset(float offsetX, float offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }
        /// <summary>
        ///     Offsets this rectangle.
        /// </summary>
        /// <param name="offset"></param>
        public void Offset(Vector2 offset) => Offset(offset.X, offset.Y);
        /// <summary>
        ///     Offsets this rectangle.
        /// </summary>
        /// <param name="offset"></param>
        public void Offset(Point offset) => Offset(offset.X, offset.Y);

        public static bool operator ==(RectangleF a, RectangleF b) 
        {
            return a.Equals(b);
        }
        public static bool operator !=(RectangleF a, RectangleF b)
        {
            return !a.Equals(b);
        }
        public static implicit operator RectangleF(Rectangle rect)
        {
            return new RectangleF
            {
                X = rect.X, Y = rect.Y,
                Width = rect.Width, Height = rect.Height
            };
        }

        public bool Equals(RectangleF other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }
        public override bool Equals(object? obj)
        {
            if (obj is RectangleF rectf)
            {
                return Equals(rectf);
            }
            else if (obj is Rectangle rect) 
            {
                return Equals((RectangleF) rect);
            }
            return false;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
