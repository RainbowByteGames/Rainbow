using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowByte.Engine.Graphics.Rendering
{
    public class RenderPipeline
    {
        /// <summary>
        ///     Gets all the render contexts.
        /// </summary>
        private List<RenderContext> Contexts { get; } = new List<RenderContext>();

        /// <summary>
        ///     Gets the sprite batch.
        /// </summary>
        public SpriteBatch SpriteBatch { get; }
        /// <summary>
        ///     Gets the current context.
        /// </summary>
        public RenderContext Context => Contexts[ContextID];
        /// <summary>
        ///     Gets or sets the current context ID.
        /// </summary>
        public int ContextID { get; set; } = 0;

        public RenderPipeline(GraphicsDevice graphicsDevice)
        {
            SpriteBatch = new SpriteBatch(graphicsDevice);
            RenderContext ctx = new RenderContext(SpriteBatch);
            Contexts.Add(ctx);
        }

        /// <summary>
        ///     Adds a new context and returns the ID.
        /// </summary>
        public int AddContext()
        {
            Contexts.Add(new RenderContext(SpriteBatch));
            return Contexts.Count - 1;
        }

        /// <summary>
        ///     Draws a texture to the context.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="transform"></param>
        public void Draw(Texture2D texture, Transform transform)
        {
            Context.Draw(texture, transform);
        }
        /// <summary>
        ///     Draws a string to the context.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="transform"></param>
        public void DrawString(SpriteFont font, string text, Transform transform)
        {
            Context.DrawString(font, text, transform);
        }
        /// <summary>
        ///     Flushes all draw calls to the SpriteBatch.
        /// </summary>
        /// <param name="transformMatrix"></param>
        public void Flush(Matrix transformMatrix)
        {
            foreach (RenderContext ctx in Contexts)
            {
                ctx.Flush(transformMatrix);
            }
        }
    }
}
