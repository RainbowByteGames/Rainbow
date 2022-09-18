using HappiiDreamer.Rainbow.State;

namespace HappiiDreamer.Rainbow
{
    public abstract class RainbowState : GameState
    {
        public RainbowGame Rainbow { get; }

        public RainbowState(StateManager states, int id) : base(states, id)
        {
            Rainbow = (RainbowGame) Game;
        }
    }
}
