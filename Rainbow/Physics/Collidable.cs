using Microsoft.Xna.Framework;

namespace RainbowByte.Engine.Physics
{
    public abstract class Collidable : GameObject
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
        ///     Gets whether this body is awake and should be simulated.
        /// </summary>
        public bool IsAwake { get; set; }
        public override bool IsUpdatable => true;
        public override bool IsDrawable => false;

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
        ///     Called when a collision is detected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnCollision(object? sender, CollisionEventArgs args) { }
    }
}
