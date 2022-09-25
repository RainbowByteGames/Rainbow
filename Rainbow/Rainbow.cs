﻿using RainbowByte.Rainbow.State;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RainbowByte.Rainbow
{
    /// <summary>
    ///     A static class that contains the latest RainbowGame instance.
    /// </summary>
    public static class Rainbow
    {
        // THIS IS A TEST COMMIT!

        internal static RainbowGame? _instance;
        /// <summary>
        ///     Gets the latest RainbowGame instance.
        /// </summary>
        public static RainbowGame Instance
        {
            get => _instance ?? throw new NullReferenceException("No RainbowGame instance has been set.");
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
    }
}
