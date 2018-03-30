using Hatchet.Graphics;
using Hatchet.Graphics.Collections;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using System;

namespace Hatchet.UnitTest.Engine.Graphics
{
    [TestFixture]
    public class AnimatorTest
    {
        [Test]
        public void Animator_PlayNullAnimation_ThrowsArgumentNullExceptioN()
        {
            Assert.Throws<ArgumentNullException>(() => MockObjects.NewAnimator.Play(null));
        }

        [Test]
        public void Animator_PlayEmptyAnimation_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => MockObjects.NewAnimator.Play(MockObjects.EmptyAnimation));
        }

        [Test]
        public void Animator_PlayNewAnimation_ReturnsTrue()
        {
            Assert.IsTrue(MockObjects.NewAnimator.Play(MockObjects.BasicAnimation));
        }
        
        [Test]
        public void Animator_PlayRepeatAnimation_ReturnsFalse()
        {
            IAnimator Animator = MockObjects.NewAnimator;
            Animator.Play(MockObjects.BasicAnimation);
            Assert.IsFalse(Animator.Play(MockObjects.BasicAnimation));
        }

        [Test]
        public void Animator_PlayDifferentAnimation_ReturnsTrue()
        {
            IAnimator Animator = MockObjects.NewAnimator;
            Animator.Play(MockObjects.BasicAnimation);
            Assert.IsTrue(Animator.Play(MockObjects.AlternativeAnimation));
        }

        [Test]
        public void Animator_ResetWhileAnimatorIsPlaying_ReturnsTrue()
        {
            IAnimator Animator = MockObjects.NewAnimator;
            Animator.Play(MockObjects.BasicAnimation);
            Assert.IsTrue(Animator.Reset());
        }

        [Test]
        public void Animator_ResetWhileAnimatorIsPlayingAndIfPlayingIsFalse_ReturnsFalse()
        {
            IAnimator Animator = MockObjects.NewAnimator;
            Animator.Play(MockObjects.BasicAnimation);
            Assert.IsFalse(Animator.Reset(false));
        }
    }

    public class MockObjects
    {
        public static IAnimator NewAnimator { get { return new Animator(); } }

        public static IAnimation emptyAnimation;
        public static IAnimation EmptyAnimation { get { if (emptyAnimation == null) emptyAnimation = new MockAnimation(); return emptyAnimation; } }
        static IAnimation basicAnimation;
        public static IAnimation BasicAnimation { get { if (basicAnimation == null) basicAnimation = new MockAnimation() { FrameContainer = ToFrameContainer(new IFrameBase[] { new MockFrame() { SourceRect = Rectangle.Empty, Duration = 1f } }) }; return basicAnimation; } }
        static IAnimation alternativeAnimation;
        public static IAnimation AlternativeAnimation { get { if (alternativeAnimation == null) alternativeAnimation = new MockAnimation() { FrameContainer = ToFrameContainer(new IFrameBase[] { new MockFrame() { SourceRect = Rectangle.Empty, Duration = 0.5f } }), Loop = true }; return alternativeAnimation; } }
        
        public static IFrameCollection ToFrameContainer(IFrameBase[] frameArray)
        {
            IFrameCollection container = new Hatchet.Graphics.Collections.XML.FrameCollection() { Frames = new System.Collections.Generic.List<IFrame>() };
            foreach (var frame in frameArray)
            {
                container.Add(new Hatchet.Graphics.XML.Frame(null, frame.SourceRect, frame.Duration));
            }
            return container;
        }
    }

    public class MockAnimation : IAnimation
    {
        public IFrameCollection FrameContainer { get; set; }

        public bool Loop { get; set; }
    }

    public class MockFrame : IFrameBase
    {
        public Rectangle SourceRect { get; set; }
        public float Duration { get; set; }
    }
}
