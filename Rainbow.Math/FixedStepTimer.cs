namespace HappiiDreamer.Rainbow.Math
{
    /// <summary>
    ///     A StepTimer which each step is the same length.
    /// </summary>
    public class FixedStepTimer : StepTimer
    {
        /// <summary>
        ///     Gets or sets the time step (default: 1 / 60th of a second).
        /// </summary>
        public TimeSpan TimeStep { get; set; } = TimeSpan.FromSeconds(1 / 60.0);
        /// <summary>
        ///     Gets or sets the steps per second (default: 60)
        /// </summary>
        public double StepsPerSecond
        {
            get => 1 / TimeStep.TotalSeconds;
            set => TimeStep = TimeSpan.FromSeconds(1 / value);
        }

        public override bool TryStep(out TimeSpan deltaTime)
        {
            if (TotalTime >= TimeStep)
            {
                TotalTime -= TimeStep;
                deltaTime = TimeStep;
                return true;
            }
            else
            {
                deltaTime = TimeSpan.Zero;
                return false;
            }
        }
    }
}
