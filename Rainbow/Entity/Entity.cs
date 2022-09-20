using HappiiDreamer.Rainbow.Physics;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Entity
{
    public abstract class Entity : GameObject
    {
        /// <summary>
        ///     Gets this entity's body.
        /// </summary>
        public KineticBody2D Body { get; }
        /// <summary>
        ///     Gets or sets the body's position.
        /// </summary>
        public Vector2 Position
        {
            get => Body.Position;
            set => Body.Position = value;
        }

        public Entity()
        {
            Body = new KineticBody2D()
            {
                Parent = this
            };
        }
    }
}
