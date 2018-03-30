using System.Collections.ObjectModel;

namespace Hatchet.Graphics.Collections
{
    public class FrameCollection : IFrameCollection
    {
        public Collection<IFrame> Frames { get; protected set; }

        public void Initialize()
        {
        }

        public IFrame this[int index] { get { return Frames[index]; } }
}
}
