using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Rainbow.Graphics
{
    /// <summary>
    ///     A class which can project and unproject a virtual resolution onto
    ///     the viewport.
    /// </summary>
    public class Camera2D
    {
        /// <summary>
        ///     Gets the transformation matrix.
        /// </summary>
        public Matrix Transform { get; private set; }
        /// <summary>
        ///     Gets the inverted transformation matrix.
        /// </summary>
        public Matrix InverseTransform { get; private set; }

        /// <summary>
        ///     Gets or sets the virtual height (double the orthographic size).
        /// </summary>
        public float VirtualHeight
        {
            get { return OrthographicSize * 2; }
            set { OrthographicSize = value / 2; }
        }
        /// <summary>
        ///     Gets or sets the orthographic size.
        /// </summary>
        public float OrthographicSize { get; set; }

        /// <summary>
        ///     Gets or sets the camera's position in the world.
        /// </summary>
        public Vector2 Position { get; set; } = Vector2.Zero;
        /// <summary>
        ///     Gets or sets the camera's zoom.
        /// </summary>
        public float Zoom { get; set; } = 0f;
        /// <summary>
        ///     Gets the zoom's magnification scale.
        /// </summary>
        public float ZoomScale
        {
            get
            {
                if (Zoom < 0) return 1 / (-Zoom + 1);
                else return Zoom + 1;
            }
        }

        /// <summary>
        ///     Updates the projection matrix based on the given viewport.
        /// </summary>
        /// <param name="viewport"></param>
        public void UpdateMatrix(Viewport viewport)
        {
            // Create initial viewport.
            Matrix m = Matrix.Multiply(
                Matrix.CreateScale(viewport.Height / VirtualHeight),
                Matrix.CreateTranslation(viewport.Width / 2, viewport.Height / 2, 0)
            );

            // Apply zoom
            m = Matrix.Multiply(
                Matrix.CreateScale(ZoomScale), m
            );

            // Translate camera in world space.
            m = Matrix.Multiply(
                Matrix.CreateTranslation(-Position.X, -Position.Y, 0), m
            );

            Transform = m;
            InverseTransform = Matrix.Invert(m);
        }

        /// <summary>
        ///     Transforms a screen space vector to a world space vector.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector2 ScreenToWorld(Vector2 position)
        {
            return Vector2.Transform(position, InverseTransform);
        }
        /// <summary>
        ///     Transforms a screen space vector to a world space vector.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector2 ScreenToWorld(Point position) => ScreenToWorld(position.ToVector2());

        /// <summary>
        ///     Transforms a world space vector to a screen space vector.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector2 WorldToScreen(Vector2 position)
        {
            return Vector2.Transform(position, Transform);
        }
    }
}