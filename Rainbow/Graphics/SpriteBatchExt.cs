using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RainbowByte.Engine.Graphics
{
    /// <summary>
    ///     Some extension methods for the SpriteBatch.
    /// </summary>
    public static class SpriteBatchExt
    {
        /// <summary>
        ///     Draws a sprite to the sprite batch.
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        public static void Draw(this SpriteBatch batch, Sprite sprite, Vector2 position, float z, Vector2 scale, float rotation)
        {
            batch.Draw(sprite.Texture, position, sprite.SourceRectangle, sprite.Color, rotation, new Vector2
            {
                X = sprite.Origin.X * sprite.SourceRectangle.Width,
                Y = sprite.Origin.Y * sprite.SourceRectangle.Height
            }, scale / sprite.PixelsPerUnit, sprite.Effects, z);
        }
        /// <summary>
        ///     Draws a texture using a transform.
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="texture"></param>
        /// <param name="transform"></param>
        public static void Draw(this SpriteBatch batch, Texture2D texture, Transform transform)
        {
            batch.Draw(texture, transform.Position, transform.SourceRectangle, transform.Color, transform.Rotation, new Vector2
            {
                X = transform.Origin.X * transform.SourceRectangle.Width,
                Y = transform.Origin.Y * transform.SourceRectangle.Height
            }, transform.Scale / transform.PixelsPerUnit, transform.Effects, transform.Z);
        }

        /// <summary>
        ///     Draws text using a transform.
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="transform"></param>
        public static void DrawString(this SpriteBatch batch, SpriteFont font, string text, Transform transform)
        {
            Vector2 size = font.MeasureString(text);
            batch.DrawString(font, text, transform.Position, transform.Color, transform.Rotation, new Vector2
            {
                X = transform.Origin.X * size.X,
                Y = transform.Origin.Y * size.Y
            }, transform.Scale / transform.PixelsPerUnit, transform.Effects, transform.Z);
        }
    }
}
