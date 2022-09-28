using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowByte.Engine.Graphics
{
    /// <summary>
    ///     A graphics structure for modifing draw calls.
    /// </summary>
    public struct Transform
    {
        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        ///     Gets or sets the Z position (sprite layer).
        /// </summary>
        public float Z { get; set; }
        /// <summary>
        ///     Gets or sets the 3D position (Position and Z [sprite layer]).
        /// </summary>
        public Vector3 Position3
        {
            get => new Vector3(Position.X, Position.Y, Z);
            set
            {
                Position = new Vector2(value.X, value.Y);
                Z = value.Z;
            }
        }

        /// <summary>
        ///     Gets or sets the SourceRectangle (does not affect text).
        /// </summary>
        public Rectangle SourceRectangle { get; set; }
        /// <summary>
        ///     Gets or sets the origin.
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        ///     Gets or sets the scale.
        /// </summary>
        public Vector2 Scale { get; set; }
        /// <summary>
        ///     Gets or sets the pixels per unit.
        /// </summary>
        public int PixelsPerUnit { get; set; }

        /// <summary>
        ///     Gets or sets the rotation.
        /// </summary>
        public float Rotation { get; set; }
        
        /// <summary>
        ///     Gets or sets the color.
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        ///     Gets or sets the effects.
        /// </summary>
        public SpriteEffects Effects { get; set; }

        
        public Transform()
        {
            Position = Vector2.Zero;
            Z = 0;
            Origin = Vector2.Zero;

            SourceRectangle = new Rectangle();

            PixelsPerUnit = 100;
            Scale = Vector2.One;

            Rotation = 0;

            Color = Color.White;
            Effects = SpriteEffects.None;
        }
    }
}
