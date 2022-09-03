using Microsoft.Xna.Framework;

namespace Rainbow.Physics
{
    public class KineticBody2D
    {
        /// <summary>
        ///     Gets the position of the body.
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        ///     Gets or sets the body's collider.
        /// </summary>
        public ICollider2D? Collider { get; private set; }
        /// <summary>
        ///     Gets or sets the velocity.
        /// </summary>
        public Vector2 Velocity { get; set; }

        public KineticBody2D() { }
        public KineticBody2D(ICollider2D collider)
        {
            SetCollider(collider);
        }

        public virtual void Update(GameTime gameTime)
        {
            Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        ///     Sets this bodies collider.
        /// </summary>
        /// <param name="collider"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetCollider(ICollider2D? collider)
        {
            if (collider == null)
            {
                if (Collider != null) Collider.Body = null;
                return;
            }

            if (collider.Body != null)
            {
                throw new InvalidOperationException("Collider already has a parent body.");
            }
            collider.Body = this;
            Collider = collider;
        }
        /// <summary>
        ///     Removes the collider from this body.
        /// </summary>
        public void RemoveCollider() => SetCollider(null);
    }
}
