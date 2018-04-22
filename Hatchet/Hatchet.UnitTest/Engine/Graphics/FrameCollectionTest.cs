using Hatchet.Graphics;
using Hatchet.Graphics.Collections.XML;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using System.Collections.Generic;

namespace Hatchet.UnitTest.Engine.Graphics
{
    [TestFixture]
    public class FrameCollectionTest
    {
        [Test]
        public void XML_EquallySizedFrameContainer_Test1_ReturnsTrue()
        {
            Dictionary<int, float> dur = new Dictionary<int, float>();
            dur.Add(1, 2f);
            Point size = new Point
            {
                X = 32,
                Y = 32
            };
            EquallySizedFrameCollection FrameCollection = new EquallySizedFrameCollection() { DefaultDuration = 1, Size = size, DurationOverride = dur, Texture = new MockTexture2D() { Height = 64, Width = 64 } };

            FrameCollection.Initialize();

            Assert.IsTrue(FrameCollection.Frames[0].Duration == 1f && FrameCollection.Frames[1].Duration == 2f && FrameCollection.Frames[2].Duration == 1f && FrameCollection.Frames.Count == 4);
        }

        public class MockTexture2D : IHatchetTexture2D
        {
            public int Width { get; set; }
            public Rectangle Bounds { get; set; }
            public int Height { get; set; }

            public Microsoft.Xna.Framework.Graphics.Texture2D XNAVariant => throw new System.NotImplementedException();
        }
    }
}
