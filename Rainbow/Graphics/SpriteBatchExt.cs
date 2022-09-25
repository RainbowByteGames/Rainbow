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
    }
}
