namespace HappiiDreamer.Rainbow.Math
{
    public class FellThroughIntersectionException : Exception
    {
        public FellThroughIntersectionException(IShape2D self, IShape2D other)
            : base($"Fell through intersection check: {self.GetType().FullName} <=> {other.GetType().FullName}")
        {
        }
    }
}
