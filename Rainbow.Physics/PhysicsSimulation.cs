using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow.Physics
{
    public class PhysicsSimulation : GameSystem
    {
        public List<Collidable> Bodies { get; } = new List<Collidable>();

        public override bool IsUpdatable => true;
        public override bool IsDrawable => false;

        public PhysicsSimulation(Game game) : base(game) { }


        public override void Update(GameTime gameTime)
        {
            // Update each body.
            foreach (KineticBody2D body in Bodies)
            {
                if (!body.IsAwake) continue;
                body.Update(gameTime);
            }

            // Check the collision of each body.
            for (int i = 0; i < Bodies.Count - 1; i++)
            {
                Collidable self = Bodies[i];
                if (!self.IsAwake || self.Collider == null) continue;
                ICollider2D selfCollider = self.Collider;

                for (int j = i + 1; j < Bodies.Count; j++)
                {
                    Collidable other = Bodies[i];
                    if (!other.IsAwake || other.Collider == null) continue;

                    if (other.Collider.Intersects(selfCollider))
                    {
                        self.OnCollision(this, new CollisionEventArgs(self, other));
                        other.OnCollision(this, new CollisionEventArgs(other, self));
                    }
                }
            }
        }
    }
}
