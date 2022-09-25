using System.Collections;
using Microsoft.Xna.Framework;

namespace RainbowByte.Engine.Entity
{
    public abstract class EntitySystem<T> : IEntitySystem, IEnumerable<T> where T : Entity
    {
        public bool IsUpdatable => true;
        public bool IsDrawable => true;

        public virtual IGameObject? Parent => null;
        public virtual int UpdatePriority => 0;

        public virtual void Update(GameTime gameTime)
        {
            foreach (T entity in this)
            {
                entity.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            foreach (T entity in this)
            {
                entity.Draw(gameTime);
            }
        }

        /// <summary>
        ///     Gets all the entities.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<T> GetEntities();
        IEnumerable<Entity> IEntitySystem.GetEntities() => GetEntities();
        /// <summary>
        ///     Deactivates an entity from the system.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Destroy(T? e) { }
        void IEntitySystem.Destroy(Entity e) => Destroy(e as T);
        /// <summary>
        ///     Removes an entity from the system.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Obliterate(T? e) { }
        void IEntitySystem.Obliterate(Entity e) => Obliterate(e as T);

        public IEnumerator<T> GetEnumerator()
        {
            return GetEntities().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual bool PreDraw() { return true; }
        public virtual void PostDraw() { }
        public virtual void OnActivated(object? sender, EventArgs e) { }
        public virtual void OnDeactivated(object? sender, EventArgs e) { }
        public virtual void OnExiting(object? sender, EventArgs e) { }
    }
}
