using Microsoft.Xna.Framework.Content;
using System.Collections.ObjectModel;

namespace Hatchet.Graphics.Collections.XML
{
    public class FrameCollection : IFrameCollection
    {
        [ContentSerializer(ElementName = "Frames", CollectionItemName = "Frame")]
        public Collection<IFrame> Frames { get; set; }

        public void Initialize() { }
    }
}
