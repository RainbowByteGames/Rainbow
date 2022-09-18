using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    /// <summary>
    ///     An interface containing game methods which a single object would need.
    /// </summary>
    public interface IGameObject
    {
        public Game Game { get; }
        public IGameObject? Parent { get; }

        public bool IsUpdatable { get; }
        public void Update(GameTime gameTime);

        public bool IsDrawable { get; }
        public void Draw(GameTime gameTime);
    }
}
