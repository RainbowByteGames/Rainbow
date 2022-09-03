using Rainbow.Math;

namespace Rainbow.Physics
{
    /// <summary>
    ///     An Axis-Aligned Bounding Box collider.
    /// </summary>
    public class AABBCollider : ICollider2D
    {
        /// <summary>
        ///     Gets or sets the bounds of the collider.
        /// </summary>
        public RectangleF Bounds { get; set; }

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
            throw ICollider2DExt.NotImplemented(other);
        }
    }
}
