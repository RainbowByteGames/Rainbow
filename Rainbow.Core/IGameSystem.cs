using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    /// <summary>
    ///     An interface containing all relavent methods for a high level game system.
    /// </summary>
    public interface IGameSystem : IGameObject
    {
        public bool BeginDraw();
        public void EndDraw();

        public void OnActivated(object? sender, EventArgs e);
        public void OnDeactivated(object? sender, EventArgs e);
        public void OnExiting(object? sender, EventArgs e);
    }
}
