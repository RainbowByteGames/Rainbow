namespace RainbowByte.Rainbow
{
    /// <summary>
    ///     An abstract pooling structure with active and inactive pools.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Pool<T>
    {
        private List<T> active = new List<T>();
        private Queue<T> inactive = new Queue<T>();

        public Pool(int size)
        {
            Alloc(size);
        }
        public Pool() { }

        /// <summary>
        ///     Allocates new instances to the inactive pool.
        /// </summary>
        /// <param name="amount"></param>
        public void Alloc(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                inactive.Enqueue(Create());
            }
        }
        /// <summary>
        ///     Activates an instance or creates a new one.
        /// </summary>
        public void Spawn()
        {
            if (inactive.Count == 0)
            {
                active.Add(Create());
            }
            else
            {
                T obj = inactive.Dequeue();
                Reset(obj);

                active.Add(obj);
            }
        }
        /// <summary>
        ///     Gets all active instances.
        /// </summary>
        /// <returns></returns>
        public T[] GetActive()
        {
            return active.ToArray();
        }

        /// <summary>
        ///     Deactivates an instance.
        /// </summary>
        /// <param name="obj"></param>
        public void Destroy(T obj)
        {
            if (active.Remove(obj))
            {
                inactive.Enqueue(obj);
            }
            else
            {
                throw new ArgumentException("Cannot destroy an object that's not active.");
            }
        }
        /// <summary>
        ///     Deactivates an object and removes it from the pool.
        /// </summary>
        /// <param name="obj"></param>
        public void Obliterate(T obj)
        {
            active.Remove(obj);
        }

        /// <summary>
        ///     Creates a new instance of T.
        /// </summary>
        /// <returns></returns>
        public abstract T Create();
        /// <summary>
        ///     Resets an instance of T.
        /// </summary>
        /// <param name="obj"></param>
        public abstract void Reset(T obj);
    }
}
