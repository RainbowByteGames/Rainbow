using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HappiiDreamer.Rainbow.Graphics
{
    /// <summary>
    ///     Some extension methods for the SpriteBatch.
    /// </summary>
    public static class SpriteBatchExt
    {
        /// <summary>
        ///     Draws a texture to the sprite batch.
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="texture"></param>
        /// <param name="transform"></param>
        /// <param name="pixelsPerUnit"></param>
        /// <param name="sourceRectangle"></param>
        /// <param name="color"></param>
        /// <param name="normalOrigin"></param>
        /// <param name="effects"></param>
        /// <param name="layer"></param>
        public static void Draw(this SpriteBatch batch, Texture2D texture, Transform2D transform, int pixelsPerUnit, Rectangle sourceRectangle, Color color, Vector2 normalOrigin, SpriteEffects effects, int layer)
        {
            batch.Draw(texture, transform.Position, sourceRectangle, color, transform.Rotation, new Vector2
            {
                X = normalOrigin.X * sourceRectangle.Width,
                Y = normalOrigin.Y * sourceRectangle.Height
            }, transform.Scale / pixelsPerUnit, effects, layer);
        }
        /// <summary>
        ///     Draws a sprite to the sprite batch.
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="sprite"></param>
        /// <param name="transform"></param>
        public static void Draw(this SpriteBatch batch, Sprite sprite, Transform2D transform)
        {
            batch.Draw(sprite.Texture, transform, sprite.PixelsPerUnit, sprite.SourceRectangle, sprite.Color, sprite.Origin, sprite.Effects, sprite.Layer);
        }
    }
}
