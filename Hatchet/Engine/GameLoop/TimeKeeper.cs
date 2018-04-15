using Microsoft.Xna.Framework;

namespace Hatchet.GameLoop
{
    public class TimeKeeper : ITimeKeeper
    {
        public float AsMilliseconds { get; private set; }
        public float AsSeconds { get => AsMilliseconds / 1000; set => AsMilliseconds = value * 1000; }
        public float AsMinutes { get => AsMilliseconds / 60000; set => AsMilliseconds = value * 60000; }
        public float AsHours { get => AsMilliseconds / 3600000; set => AsMilliseconds = value * 3600000; }
        public float AsDays { get => AsMilliseconds / 86400000; set => AsMilliseconds = value * 86400000; }

        public void Update(GameTime gameTime) => AsMilliseconds += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        public void Restart() => AsMilliseconds = 0;
    }
}
