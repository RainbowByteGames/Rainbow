namespace Rainbow.State
{
    /// <summary>
    ///     An exception for state errors.
    /// </summary>
    public class RainbowStateException : Exception
    {
        public RainbowStateException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
