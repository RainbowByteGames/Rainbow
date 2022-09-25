using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowByte.Engine.Entity
{
    /// <summary>
    ///     An interface for an entity system.
    /// </summary>
    public interface IEntitySystem : IGameSystem
    {
        public IEnumerable<Entity> GetEntities();

        public void Destroy(Entity e);
        public void Obliterate(Entity e);
    }
}
