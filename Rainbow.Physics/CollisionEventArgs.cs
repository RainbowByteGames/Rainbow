namespace HappiiDreamer.Rainbow.Physics
{
    public class CollisionEventArgs : EventArgs
    {
        public Collidable Self { get; }
        public Collidable Other { get; }
        public CollisionEventArgs(Collidable self, Collidable other)
        {
            Self = self;
            Other = other;
        }
    }
}
