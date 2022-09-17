using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Physics
{
    public class KineticBody2D : ICollidable
    {
        /// <summary>
        ///     Gets or sets the postiion.
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
        /// <summary>
        ///     Gets or sets the validation function for this body.
        /// </summary>
        public Action? Validate { get; set; }

        public virtual void Update(GameTime gameTime)
        {
            Move(Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds);
            Validate?.Invoke();
        }


        /// <summary>
        ///     Creates and sets a collider for this body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SetCollider<T>() where T : ICollider2D
        {
            T? collider = (T?) Activator.CreateInstance(typeof(T), this);
            if (collider == null)
            {
                throw new NullReferenceException("Could not create collider.");
            }

            return collider;
        }
        /// <summary>
        ///     Removes the collider from this body.
        /// </summary>
        public void RemoveCollider()
        {
            Collider = null;
            // TODO: make collider unusable?
        }

        /// <summary>
        ///     Moves the body to a specific position.
        /// </summary>
        /// <param name="pos"></param>
        public void MoveTo(Vector2 pos)
        {
            Position = pos;
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
            Position += delta;
        }
        /// <summary>
        ///     Moves the body.
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void Move(float dx, float dy) => Move(new Vector2(dx, dy));
    }
}
