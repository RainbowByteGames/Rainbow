using RainbowByte.Engine.State;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RainbowByte.Engine
{
    /// <summary>
    ///     A static class that contains the latest RainbowGame instance.
    /// </summary>
    public static class Rainbow
    {
        internal static RainbowGame? _instance;
        /// <summary>
        ///     Gets the latest RainbowGame instance.
        /// </summary>
        public static RainbowGame Instance
        {
            get => _instance ?? throw new NullReferenceException("No RainbowGame instance has been set.");
        }

        /// <summary>
        ///     Gets the instance as a specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static T InstanceAs<T>() where T : RainbowGame
        {
            return Instance as T ?? throw new InvalidCastException($"Instance is not of type {typeof(T).FullName}");
        }

        /// <summary>
        ///     Gets whether the game is active.
        /// </summary>
        public static bool IsActive => Instance.IsActive;
        /// <summary>
        ///     Gets the game's content manager.
        /// </summary>
        public static ContentManager Content => Instance.Content;
        /// <summary>
        ///     Gets the game's graphics device.
        /// </summary>
        public static GraphicsDevice GraphicsDevice => Instance.GraphicsDevice;
        /// <summary>
        ///     Gets the game's window.
        /// </summary>
        public static GameWindow Window => Instance.Window;

        /// <summary>
        ///     Gets the current StateManager.
        /// </summary>
        public static StateManager States => Instance.States;
        /// <summary>
        ///     Gets the current SpriteBatch.
        /// </summary>
        public static SpriteBatch SpriteBatch => Instance.SpriteBatch;

        /// <summary>
        ///     Exits the game.
        /// </summary>
        public static void Exit() => Instance.Exit();
    }
}
