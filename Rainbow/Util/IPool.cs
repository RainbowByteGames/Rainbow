namespace RainbowByte.Engine.Util
{
    /// <summary>
    ///     A pool interface.
    /// </summary>
    public interface IPool
    {
        /// <summary>
        ///     Allocates inactive objects.
        /// </summary>
        /// <param name="size"></param>
        public void Alloc(int size);

        /// <summary>
        ///     Spawns a new object in the pool.
        /// </summary>
        /// <returns></returns>
        public object Spawn();
        /// <summary>
        ///     Gets all active objects in the pool.
        /// </summary>
        /// <returns></returns>
        public object[] GetActive();
        /// <summary>
        ///     Deactivates an active object.
        /// </summary>
        /// <param name="obj"></param>
        public void Destroy(object? obj);
        /// <summary>
        ///     Removes the object from the pool.
        /// </summary>
        /// <param name="obj"></param>
        public void Obliterate(object? obj);
    }
    /// <summary>
    ///     A pool interface with generics.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPool<T> : IPool
    {
        /// <summary>
        ///     Spawns a new object in the pool.
        /// </summary>
        /// <returns></returns>
        public new T Spawn();
        /// <summary>
        ///     Gets all active objects in the pool.
        /// </summary>
        /// <returns></returns>
        public new T[] GetActive();
        /// <summary>
        ///     Deactivates an active object.
        /// </summary>
        /// <param name="obj"></param>
        public void Destroy(T? obj);
        /// <summary>
        ///     Removes the object from the pool.
        /// </summary>
        /// <param name="obj"></param>
        public void Obliterate(T? obj);
    }
}
