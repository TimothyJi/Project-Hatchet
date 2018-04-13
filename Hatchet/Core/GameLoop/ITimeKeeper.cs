using Microsoft.Xna.Framework;

namespace Hatchet.GameLoop
{
    public interface ITimeKeeper
    {
        float ElapsedTimeInDays { get; }
        float ElapsedTimeInHours { get; }
        float ElapsedTimeInMilliseconds { get; }
        float ElapsedTimeInMinutes { get; }
        float ElapsedTimeInSeconds { get; }

        void Restart();
        void Update(GameTime gameTime);
    }
}