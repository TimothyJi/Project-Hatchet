using Hatchet.Graphics;
using Hatchet.Graphics.Collections;
using Hatchet.Graphics.Collections.XML;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            Point size = new Point();
            size.X = 32; size.Y = 32;
            IFrameCollection frameContainer = new EquallySizedFrameCollectior() { Frames = new Collection<IFrame>(), DefaultDuration = 1, Size = size, DurationOverride = dur, Texture = new MockTexture2D() { Height = 64, Width = 64 } };

            frameContainer.Initialize();

            Assert.IsTrue(frameContainer.Frames[0].Duration == 1f && frameContainer.Frames[1].Duration == 2f && frameContainer.Frames[2].Duration == 1f && frameContainer.Frames.Count == 4);
        }

        public class MockTexture2D : ITexture2D
        {
            public int Width { get; set; }
            public Rectangle Bounds { get; set; }
            public int Height { get; set; }

            public Microsoft.Xna.Framework.Graphics.Texture2D XNAVariant => throw new System.NotImplementedException();
        }
    }
}
