namespace RainbowByte.Engine.Util
{
    /// <summary>
    ///     An abstract pooling structure with active and inactive pools.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pool<T> : IPool<T> where T : class
    {
        private readonly List<T> active = new List<T>();
        private readonly Queue<T> inactive = new Queue<T>();

        /// <summary>
        ///     Gets or sets the create function.
        /// </summary>
        public Func<T> Create { get; set; }
        /// <summary>
        ///     Gets or sets the reset function.
        /// </summary>
        public Action<T>? Reset { get; set; }

        public Pool(Func<T> create, int size) : this(create)
        {
            Alloc(size);
        }
        public Pool(Func<T> create)
        {
            Create = create;
        }

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
        public T Spawn()
        {
            T obj;
            if (inactive.Count == 0)
            {
                obj = Create();
            }
            else
            {
                obj = inactive.Dequeue();
                Reset?.Invoke(obj);
            }

            active.Add(obj);
            return obj;
        }
        object IPool.Spawn() => Spawn()!;

        /// <summary>
        ///     Gets all active instances.
        /// </summary>
        /// <returns></returns>
        public T[] GetActive()
        {
            return active.ToArray();
        }
        object[] IPool.GetActive() => (GetActive() as object[])!;

        /// <summary>
        ///     Deactivates an instance.
        /// </summary>
        /// <param name="obj"></param>
        public void Destroy(T? obj)
        {
            if (obj == null) return;
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
        public void Obliterate(T? obj)
        {
            if (obj == null) return;
            active.Remove(obj);
        }

        public void Destroy(object? obj) => Destroy(obj as T);
        public void Obliterate(object? obj) => Obliterate(obj is T);
    }
}
