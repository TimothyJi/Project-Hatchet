using Microsoft.Xna.Framework;

namespace Hatchet.GameLoop
{
    public class TimeKeeper : ITimeKeeper
    {
        public float ElapsedTimeInMilliseconds { get; private set; }
        public float ElapsedTimeInSeconds { get => ElapsedTimeInMilliseconds / 1000; set => ElapsedTimeInMilliseconds = value * 1000; }
        public float ElapsedTimeInMinutes { get => ElapsedTimeInMilliseconds / 60000; set => ElapsedTimeInMilliseconds = value * 60000; }
        public float ElapsedTimeInHours { get => ElapsedTimeInMilliseconds / 3600000; set => ElapsedTimeInMilliseconds = value * 3600000; }
        public float ElapsedTimeInDays { get => ElapsedTimeInMilliseconds / 86400000; set => ElapsedTimeInMilliseconds = value * 86400000; }

        public void Update(GameTime gameTime) => ElapsedTimeInMilliseconds += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        public void Restart() => ElapsedTimeInMilliseconds = 0;
    }
}
