using System.Collections;
using Microsoft.Xna.Framework;

namespace RainbowByte.Engine.Entity
{
    public abstract class EntitySystem<T> : GameSystem, IEnumerable<T> where T : Entity
    {
        public override bool IsUpdatable => true;
        public override bool IsDrawable => true;

        public override void Update(GameTime gameTime)
        {
            foreach (T entity in this)
            {
                entity.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (T entity in this)
            {
                entity.Draw(gameTime);
            }
        }


        public abstract IEnumerable<T> GetEntities();

        public IEnumerator<T> GetEnumerator()
        {
            return GetEntities().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
