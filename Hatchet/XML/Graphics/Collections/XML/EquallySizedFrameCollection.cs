using Hatchet.Graphics.XML;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hatchet.Graphics.Collections.XML
{
    public class EquallySizedFrameCollectior : IFrameCollection
    {
        [ContentSerializerIgnore]
        public Collection<IFrame> Frames { get; set; }

        public ITexture2D Texture { get; set; }
        public Point Size { get; set; }
        public float DefaultDuration { get; set; }

        [ContentSerializer(ElementName = "Durations", CollectionItemName = "Override")]
        public Dictionary<int, float> DurationOverride { get; set; }

        public void Initialize()
        {
            int columns = Texture.Width / Size.X;
            int rows = Texture.Height / Size.Y;
            int totalFrames = columns * rows;
            
            for (int index = 0; index < totalFrames; index++)
            {
                int x = (index % columns) * Size.X;
                int y = (int)Math.Round((double)(index / columns)) * Size.Y;
                Point loc = new Point(x, y);
                IFrame frame = new Frame(Texture, new Rectangle(loc, Size), DurationOverride.ContainsKey(index) ? DurationOverride[index] : DefaultDuration);

                Frames.Add(frame);
            }
        }
    }
}
