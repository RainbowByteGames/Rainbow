namespace RainbowByte.Rainbow.Physics
{
    public class FellThroughCollisionException : Exception
    {
        public FellThroughCollisionException(ICollider2D self, ICollider2D other)
            : base($"Fell through intersection check: {self.GetType().FullName} <=> {other.GetType().FullName}")
        {
        }
    }
}
