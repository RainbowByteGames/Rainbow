namespace HappiiDreamer.Rainbow.Physics
{
    /// <summary>
    ///     An abstract type that can be collided with.
    /// </summary>
    public interface ICollidable : IPositionable
    {
        /// <summary>
        ///     Gets this objects collider.
        /// </summary>
        public ICollider2D? Collider { get; }
    }
}
