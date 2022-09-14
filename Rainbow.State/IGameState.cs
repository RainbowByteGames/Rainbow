namespace HappiiDreamer.Rainbow.State
{
    /// <summary>
    ///     An interface containing all relavent methods for a game state.
    /// </summary>
    public interface IGameState : IGameSystem
    {
        public void LoadContent() { }
        public void UnloadContent() { }
    }
}
