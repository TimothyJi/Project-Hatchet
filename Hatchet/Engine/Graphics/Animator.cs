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

        public float TimeElasped { get; private set; }

        public bool Play(IAnimation animation)
        {
            if (animation == null || CurrentAnimation != animation)
                CurrentAnimation = animation ?? throw new ArgumentNullException();
            else
                return false;
            if (animation.FrameContainer.Frames == null)
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
            TimeElasped = 0;
            IsPlaying = true;

            return true;
        }

        public void Update(GameTime gameTime)
        {
            if (IsPlaying == false)
                return;
            else if (CurrentAnimation == null)
                throw new NullReferenceException("Cannot play a null Animation");

            TimeElasped += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (TimeElasped > CurrentFrame.Duration)
            {
                TimeElasped -= CurrentFrame.Duration;

                if (CurrentAnimation.Loop)
                    CurrentFrameIndex = (CurrentFrameIndex + 1) % CurrentAnimation.FrameContainer.GetLength();
                else
                {
                    CurrentFrameIndex = Math.Min(CurrentFrameIndex, CurrentAnimation.FrameContainer.GetLength());
                    if (CurrentFrameIndex >= CurrentAnimation.FrameContainer.GetLength())
                    {
                        IsPlaying = false;
                        break;
                    }
                }
            }
        }
    }
}
