using System.Collections.Generic;

namespace Hatchet.Graphics.Collections
{
    public interface IFrameCollection
    {
        List<IFrame> Frames { get; }

        void Initialize();
    }

    public static class FrameContainerExtensions
    {
        public static void Add(this IFrameCollection container, IFrame frame)
        {
            container.Frames.Add(frame);
        }

        public static int GetLength(this IFrameCollection container)
        {
            return container.Frames.Count;
        }
    }
}
