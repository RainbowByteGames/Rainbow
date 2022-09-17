using Microsoft.Xna.Framework;

namespace HappiiDreamer.Rainbow
{
    /// <summary>
    ///     A structure containing 2D position, scale, and rotation.
    /// </summary>
    public class Transform2D
    {
        /// <summary>
        ///     Gets the object which owns this transform.
        /// </summary>
        public ITransformable Object { get; }

        private Transform2D? _parent;
        /// <summary>
        ///     Gets or sets the parent of the transform.
        /// </summary>
        public Transform2D? Parent
        {
            get => _parent;
            set
            {
                _parent?._children.Remove(this);

                value?.Cascade(parent =>
                {
                    if (parent == this)
                    {
                        throw new InvalidOperationException("Circular parents are not supported.");
                    }
                });

                _parent = value;
                _parent?._children.Add(this);
            }
        }
        /// <summary>
        ///     Gets whether this transform is the root.
        /// </summary>
        public bool IsRoot => Parent == null;

        private List<Transform2D> _children = new List<Transform2D>();
        /// <summary>
        ///     Gets the children of this transform.
        /// </summary>
        public Transform2D[] Children => _children.ToArray();

        /// <summary>
        ///     Gets or sets the local position.
        /// </summary>
        public Vector2 LocalPosition { get; set; }
        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                Vector2 pos = LocalPosition;
                Cascade(parent => 
                {
                    pos += parent.LocalPosition;
                });
                return pos;
            }
            set
            {
                Vector2 pos = value;
                Cascade(parent =>
                {
                    pos -= parent.LocalPosition;
                });
                LocalPosition = pos;
            }
        }

        /// <summary>
        ///     Gets or sets the local scale.
        /// </summary>
        public Vector2 LocalScale { get; set; }
        /// <summary>
        ///     Gets or sets the scale.
        /// </summary>
        public Vector2 Scale
        {
            get
            {
                Vector2 scale = LocalScale;
                Cascade(parent =>
                {
                    scale += parent.LocalScale;
                });
                return scale;
            }
            set
            {
                Vector2 scale = value;
                Cascade(parent =>
                {
                    scale -= parent.LocalScale;
                });
                LocalScale = scale;
            }
        }

        /// <summary>
        ///     Gets or sets the local rotation.
        /// </summary>
        public float LocalRotation { get; set; }
        /// <summary>
        ///     Gets or sets the rotation.
        /// </summary>
        public float Rotation
        {
            get
            {
                float rot = LocalRotation;
                Cascade(parent =>
                {
                    rot += parent.LocalRotation;
                });
                return rot;
            }
            set
            {
                float rot = value;
                Cascade(parent =>
                {
                    rot -= parent.LocalRotation;
                });
                LocalRotation = rot;
            }
        }


        public Transform2D(ITransformable obj)
        {
            Object = obj;
        }

        /// <summary>
        ///     Runs the callback up the parent chain.
        /// </summary>
        /// <param name="callback"></param>
        public void Cascade(Action<Transform2D> callback)
        {
            Transform2D? parent = Parent;
            while (parent != null)
            {
                callback(parent);
                parent = parent.Parent;
            }
        }
    }
}