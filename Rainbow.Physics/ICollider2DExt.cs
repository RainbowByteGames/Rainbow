namespace Rainbow.Physics
{
    public static class ICollider2DExt
    {
        /// <summary>
        ///     Checks whether this collider intersects the other collider.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool Intersects(this ICollider2D self, ICollider2D other)
        {
            return self.Intersects(other, false);
        }
        internal static NotImplementedException NotImplemented(ICollider2D other)
        {
            return new NotImplementedException($"{other.GetType().FullName} intersection not implemented.");
        }
    }
}
