using HappiiDreamer.Rainbow.Math;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Physics
{
    public class KineticBody2D
    {
        /// <summary>
        ///     Gets or sets the transform for this body.
        /// </summary>
        public Transform2D Transform { get; set; } = new Transform2D
        {
            Scale = Vector2.One
        };

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
            Move(Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        ///     Moves the body to a specific position.
        /// </summary>
        /// <param name="pos"></param>
        public void MoveTo(Vector2 pos)
        {
            Transform2D t = Transform;
            t.Position = pos;
            Transform = t;
        }
        /// <summary>
        ///     Moves the body to a specific position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo(float x, float y) => MoveTo(new Vector2(x, y));

        /// <summary>
        ///     Moves the body.
        /// </summary>
        /// <param name="v"></param>
        public void Move(Vector2 delta)
        {
            MoveTo(Transform.Position + delta);
        }
        /// <summary>
        ///     Moves the body.
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void Move(float dx, float dy) => Move(new Vector2(dx, dy));


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
