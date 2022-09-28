using Microsoft.Xna.Framework.Graphics;

namespace RainbowByte.Engine.Graphics.Rendering
{
    internal class DrawCall
    {
        /// <summary>
        ///     Gets the texture to draw.
        /// </summary>
        public Texture2D? Texture { get; }

        /// <summary>
        ///     Gets the font used to draw text.
        /// </summary>
        public SpriteFont? Font { get; }
        /// <summary>
        ///     Gets the text to draw.
        /// </summary>
        public string? Text { get; }

        /// <summary>
        ///     Gets the transform to use on the texture.
        /// </summary>
        public Transform Transform { get; }

        public DrawCall(Texture2D texture, Transform transform)
        {
            Texture = texture;
            Transform = transform;
        }
        public DrawCall(SpriteFont font, string text, Transform transform)
        {
            Font = font;
            Text = text;
            Transform = transform;
        }

        /// <summary>
        ///     Draws this to the sprite batch.
        /// </summary>
        /// <param name="batch"></param>
        public void Draw(SpriteBatch batch)
        {
            if (Texture != null)
            {
                batch.Draw(Texture, Transform);
            }
            else
            {
                batch.DrawString(Font!, Text!, Transform);
            }
        }
    }
}
