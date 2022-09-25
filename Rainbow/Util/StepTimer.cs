namespace RainbowByte.Engine
{
    /// <summary>
    ///     A class for evaluating smooth time into steps.
    /// </summary>
    public abstract class StepTimer
    {
        /// <summary>
        ///     Gets to total time passed.
        /// </summary>
        public TimeSpan TotalTime { get; protected set; }

        /// <summary>
        ///     Ellapses the timer a certain amount of time.
        /// </summary>
        /// <param name="time"></param>
        public void Ellapse(TimeSpan time) => TotalTime += time;
        /// <summary>
        ///     Attempts to step the time and outputs the delta.
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns>Whether the timestep was successfull</returns>
        public abstract bool TryStep(out TimeSpan deltaTime);
        /// <summary>
        ///     Attemps to step the time and returns the delta.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public TimeSpan Step()
        {
            if (TryStep(out TimeSpan deltaTime))
            {
                return deltaTime;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
