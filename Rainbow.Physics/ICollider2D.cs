using Rainbow.Math;

namespace Rainbow.Physics
{
    /// <summary>
    ///     An interface which describes a 2D collider.
    /// </summary>
    public interface ICollider2D
    {
        /// <summary>
        ///     Gets the bounds of this collider.
        /// </summary>
        public abstract RectangleF Bounds { get; }
        /// <summary>
        ///     Checks whether this collider intersects the other collider.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="throwback">Whether this method is thrown back from the other collider</param>
        /// <returns></returns>
        public abstract bool Intersects(ICollider2D other, bool throwback);
    }
}