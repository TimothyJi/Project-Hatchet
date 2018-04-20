using Hatchet.GameLoop;
using Hatchet.Graphics.Collections;
using Microsoft.Xna.Framework;
using System;

namespace Hatchet.Graphics
{
    public class Animator : IAnimator
    {
        public IAnimation CurrentAnimation { get; private set; }

        public int CurrentFrameIndex { get; private set; }
        public IFrame CurrentFrame => ((FrameCollection)(CurrentAnimation.FrameContainer))[CurrentFrameIndex];

        public bool IsPlaying { get; private set; }

        public TimeKeeper TimeElapsed { get; private set; }
        ITimeKeeper IAnimator.TimeElapsed => TimeElapsed;

        public bool Play(IAnimation animation)
        {
            if (animation == null || CurrentAnimation != animation)
                CurrentAnimation = animation ?? throw new ArgumentNullException();
            else
                return false;
            if (animation.FrameContainer == null)
                throw new NullReferenceException("Frames are null.");

            return Reset();
        }

        public bool Reset()
        {
            return Reset(true);
        }

        public bool Reset(bool IfPlaying)
        {
            if (!IfPlaying && IsPlaying)
                return false;

            CurrentFrameIndex = 0;
            TimeElapsed.Restart();
            IsPlaying = true;

            return true;
        }

        public void Update(GameTime gameTime)
        {
            if (IsPlaying == false)
                return;
            else if (CurrentAnimation == null)
                throw new NullReferenceException("Cannot play a null Animation");

            TimeElapsed.Update(gameTime);
            while (TimeElapsed.AsSeconds > CurrentFrame.Duration)
            {
                TimeElapsed.AsSeconds -= CurrentFrame.Duration;

                if (CurrentAnimation.Loop)
                    CurrentFrameIndex = (CurrentFrameIndex + 1) % CurrentAnimation.FrameContainer.Count;
                else
                {
                    CurrentFrameIndex = MathHelper.Min(CurrentFrameIndex, CurrentAnimation.FrameContainer.Count);
                    if (CurrentFrameIndex >= CurrentAnimation.FrameContainer.Count)
                    {
                        IsPlaying = false;
                        break;
                    }
                }
            }
        }
    }
}
