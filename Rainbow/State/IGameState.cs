namespace RainbowByte.Rainbow.State
{
    /// <summary>
    ///     An interface containing all relavent methods for a game state.
    /// </summary>
    public interface IGameState : IGameSystem
    {
        public void LoadContent() { }
        public void UnloadContent() { }

        public bool BeginDraw();
        public void EndDraw();

        public void Enter(IGameState? from);
        public void Leave(IGameState? to);
    }
}
