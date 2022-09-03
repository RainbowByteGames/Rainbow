using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Physics
{
    public class KineticBody2D
    {
        /// <summary>
        ///     Gets or sets the body's collider.
        /// </summary>
        public ICollider2D? Collider { get; set; }
    }
}
