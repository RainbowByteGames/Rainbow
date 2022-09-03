using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rainbow.Math;

namespace Rainbow.Graphics
{
    /// <summary>
    ///     A drawable object module for rendering sprites to the screen.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        ///     Gets the underlying texture for this Sprite.
        /// </summary>
        public Texture2D Texture { get; }
        /// <summary>
        ///     Gets or sets the source rectangle. (Default: Entire Texture)
        /// </summary>
        public Rectangle SourceRectangle { get; set; }
        /// <summary>
        ///     Gets or sets the layer.
        /// </summary>
        public int Layer { get; set; } = 0;
        /// <summary>
        ///     Gets or sets a normalized origin. (Default: <0.5, 0.5>)
        /// </summary>
        public Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);
        /// <summary>
        ///     Gets or sets the color. (Default: white)
        /// </summary>
        public Color Color { get; set; } = Color.White;
        /// <summary>
        ///     Gets or sets the sprite effects.
        /// </summary>
        public SpriteEffects Effects { get; set; }

        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
            this.SourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
        }
        public void Draw(SpriteBatch batch, Transform2D transform)
        {
            if (Texture.IsDisposed) return;
            batch.Draw(Texture, transform, SourceRectangle, Color, Origin, Effects, Layer);
        }
    }
}
