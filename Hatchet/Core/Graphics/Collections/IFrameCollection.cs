using System.Collections.ObjectModel;

namespace Hatchet.Graphics.Collections
{
    public interface IFrameCollection
    {
        Collection<IFrame> Frames { get; }

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
