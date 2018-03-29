using System.Collections.Generic;

namespace Hatchet.Graphics.Collections
{
    public class FrameContainer : IFrameContainer
    {
        public ITexture2D DefaultTexture { get; protected set; }
        public List<IFrame> Frames { get; protected set; }

        public void Initialize()
        {
            Frames.FindAll(frame => frame.Texture == null).ForEach(frame => ((Frame)frame).Texture = DefaultTexture);
        }
    }
}
