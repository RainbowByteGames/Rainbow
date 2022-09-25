using RainbowByte.Engine.Physics;
using Microsoft.Xna.Framework;
using RainbowByte.Engine.Graphics;

namespace RainbowByte.Engine.Entity
{
    public abstract class Entity : GameObject
    {
        public override bool IsUpdatable => true;
        public override bool IsDrawable => true;

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
        /// <summary>
        ///     Gets or sets the body's velocity.
        /// </summary>
        public Vector2 Velocity
        {
            get => Body.Velocity;
            set => Body.Velocity = value;
        }


        /// <summary>
        ///     Gets or sets this entity's sprite.
        /// </summary>
        public Sprite? Sprite { get; set; }
        /// <summary>
        ///     Gets or sets the sprite's layer.
        /// </summary>
        public float SpriteLayer { get; set; } = 0;
        /// <summary>
        ///     Gets or sets the sprite's scale.
        /// </summary>
        public Vector2 Scale { get; set; } = Vector2.One;
        /// <summary>
        ///     Gets or sets the sprite's rotation.
        /// </summary>
        public float Rotation { get; set; } = 0;

        public Entity()
        {
            Body = new KineticBody2D()
            {
                Parent = this
            };
        }

        public override void Draw(GameTime gameTime)
        {
            if (Sprite == null) return;
            Rainbow.SpriteBatch.Draw(Sprite, Position, SpriteLayer, Scale, Rotation);

            base.Draw(gameTime);
        }

        /// <summary>
        ///     Destroies this entity as long as the parent is an EntitySystem
        /// </summary>
        public void Destroy()
        {
            (Parent as IEntitySystem)?.Destroy(this);
        }
        /// <summary>
        ///     Obliterates this entity as long as the parent is an EntitySystem
        /// </summary>
        public void Obliterate()
        {
            (Parent as IEntitySystem)?.Obliterate(this);
        }
    }
}
