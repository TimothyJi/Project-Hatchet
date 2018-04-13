using Hatchet.GameLoop;
using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public interface IAnimator
    {
        IAnimation CurrentAnimation { get; }

        int CurrentFrameIndex { get; }
        IFrame CurrentFrame { get; }

        ITimeKeeper TimeElapsed { get; }

        bool IsPlaying { get; }
        bool Play(IAnimation animation);

        bool Reset();
        bool Reset(bool IfPlaying);

        void Update(GameTime gameTime);
    }
}
