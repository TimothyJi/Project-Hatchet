using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Hatchet.Graphics.Collections.XML
{
    public class FrameContainer : IFrameContainer
    {
        public ITexture2D DefaultTexture { get; set; }
        [ContentSerializer(ElementName = "Frames", CollectionItemName = "Frame")]
        public List<IFrame> Frames { get; set; } 
    }
}
