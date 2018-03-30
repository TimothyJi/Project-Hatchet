using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Hatchet.Graphics.Collections.XML
{
    public class FrameCollection : IFrameCollection
    {
        [ContentSerializer(ElementName = "Frames", CollectionItemName = "Frame")]
        public List<IFrame> Frames { get; set; }

        public void Initialize() { }
    }
}
