using Microsoft.Xna.Framework;

namespace Hatchet.GameLoop
{
    public interface ITimeKeeper
    {
        float AsDays { get; }
        float AsHours { get; }
        float AsMinutes { get; }
        float AsSeconds { get; }
        float AsMilliseconds { get; }

        void Restart();
        void Update(GameTime gameTime);
    }
}