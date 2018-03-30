using System.Collections.Generic;

namespace Hatchet.Graphics.Collections
{
    public class FrameCollection : IFrameCollection
    {
        public List<IFrame> Frames { get; protected set; }

        public void Initialize()
        {
        }

        public IFrame this[int index] { get { return Frames[index]; } }
}
}
