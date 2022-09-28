using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RainbowByte.Engine.Graphics.Rendering
{
    /// <summary>
    ///     A specific render context.
    /// </summary>
    public class RenderContext
    {
        internal Queue<DrawCall> DrawQueue { get; } = new Queue<DrawCall>();

        /// <summary>
        ///     Gets the SpriteBatch for the render context.
        /// </summary>
        public SpriteBatch SpriteBatch { get; }
        public SpriteSortMode SortMode { get; set; } = SpriteSortMode.Deferred;
        public BlendState? BlendState { get; set; } = null;
        public SamplerState? SamplerState { get; set; } = null;
        public DepthStencilState? DepthStencilState { get; set; } = null;
        public RasterizerState? RasterizerState { get; set; } = null;
        public Effect? Effect { get; set; } = null;

        public RenderContext(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        /// <summary>
        ///     Begins the draw calls.
        /// </summary>
        /// <param name="transformMatrix"></param>
        protected void Begin(Matrix transformMatrix)
        {
            SpriteBatch.Begin(SortMode, BlendState, SamplerState, DepthStencilState, RasterizerState, Effect, transformMatrix);
        }
        /// <summary>
        ///     Draws the entire queue.
        /// </summary>
        private void DrawAll()
        {
            while (DrawQueue.Count > 0)
            {
                DrawQueue.Dequeue().Draw(SpriteBatch);
            }
        }
        /// <summary>
        ///     Ends the draw calls.
        /// </summary>
        protected void End()
        {
            SpriteBatch.End();
        }

        /// <summary>
        ///     Draws a texture to the context.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="transform"></param>
        public void Draw(Texture2D texture, Transform transform)
        {
            DrawQueue.Enqueue(new DrawCall(texture, transform));
        }
        /// <summary>
        ///     Draws a string to the context.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="transform"></param>
        public void DrawString(SpriteFont font, string text, Transform transform)
        {
            DrawQueue.Enqueue(new DrawCall(font, text, transform));
        }
        /// <summary>
        ///     Flushes all draw calls to the SpriteBatch.
        /// </summary>
        /// <param name="transformMatrix"></param>
        public void Flush(Matrix transformMatrix)
        {
            Begin(transformMatrix);
            DrawAll();
            End();
        }
    }
}
