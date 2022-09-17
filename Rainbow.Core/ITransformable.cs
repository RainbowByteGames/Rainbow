namespace HappiiDreamer.Rainbow
{
    /// <summary>
    ///     An interface which is essntially an owner for a transform.
    /// </summary>
    public interface ITransformable
    {
        /// <summary>
        ///     Gets the transform for this object.
        /// </summary>
        public Transform2D Transform { get; }
    }
    public static class ITransformableExt
    {
        /// <summary>
        ///     Gets the parent of this object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ITransformable? GetParent(this ITransformable obj)
        {
            return obj.Transform.Parent?.Object;
        }
        /// <summary>
        ///     Sets the parent of this object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="parent"></param>
        public static void SetParent(this ITransformable obj, ITransformable? parent)
        {
            obj.Transform.Parent = parent?.Transform;
        }
        /// <summary>
        ///     Gets the children of this object.
        /// </summary>
        /// <returns></returns>
        public static ITransformable[] GetChildren(this ITransformable obj)
        {
            Transform2D[] childTransforms = obj.Transform.Children;
            ITransformable[] children = new ITransformable[childTransforms.Length];

            for (int i = 0; i < childTransforms.Length; i++)
            {
                children[i] = childTransforms[i].Object;
            }

            return children;
        }
    }
}
