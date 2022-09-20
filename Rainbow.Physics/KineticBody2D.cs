using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Physics
{
    public class KineticBody2D : Collidable
    {
        /// <summary>
        ///     Gets or sets the velocity.
        /// </summary>
        public Vector2 Velocity { get; set; }
        /// <summary>
        ///     Gets or sets the validation function for this body.
        /// </summary>
        public Action? Validate { get; set; }


        public override void Update(GameTime gameTime)
        {
            Move(Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds);
            Validate?.Invoke();
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
