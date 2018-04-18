using Hatchet.GameLoop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.Screen.Presets
{
    public class SplashScreen : ScreenBase
    {
        protected TimeKeeper timeKeeper;

        protected string imagePath;

        protected float displayDuration;
        protected float transitionInTime;
        protected float transitionOutTime;

        protected IScreen nextScreen;

        protected FullImage image;

        public SplashScreen(Texture2D texture, float duration, float transitionIn, float transitionOut, IScreen nextScreen)
        {
            this.displayDuration = duration;
            this.transitionInTime = transitionIn;
            this.transitionOutTime = transitionOut;
            this.nextScreen = nextScreen;

            image = new FullImage();
            image.Initialize(texture, true, 1f);
            timeKeeper = new TimeKeeper();
        }
        
        public SplashScreen(string imagePath, float duration, float transitionIn, float transitionOut, IScreen nextScreen)
        {
            this.imagePath = imagePath;
            this.displayDuration = duration;
            this.transitionInTime = transitionIn;
            this.transitionOutTime = transitionOut;
            this.nextScreen = nextScreen;

            image = new FullImage();
            timeKeeper = new TimeKeeper();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            var texture = Content.Load<Texture2D>(imagePath);
            if (imagePath != null)
            {
                image.Initialize(texture, true, 1f);
            }

            image.Alpha = 0f;
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (State != ScreenStates.Unloaded)
            {
                timeKeeper.Update(gameTime);

                switch (State)
                {
                    case ScreenStates.TransitioningIn:
                        image.Alpha = MathHelper.Min(timeKeeper.AsSeconds / transitionInTime, 1);
                        if (image.Alpha == 1)
                        {
                            State = ScreenStates.Active;
                            timeKeeper.AsSeconds -= transitionInTime;
                        }
                        break;
                    case ScreenStates.Active:
                        DoIfActive(gameTime);
                        break;
                    case ScreenStates.TransitioningOut:
                        image.Alpha = 1f - MathHelper.Min((timeKeeper.AsSeconds - (displayDuration + transitionInTime)) / transitionOutTime, 1);
                        if (image.Alpha == 0)
                        {
                            State = ScreenStates.Unloaded;
                            timeKeeper.AsSeconds -= transitionInTime;
                        }
                        break;
                }
            }
        }

        public virtual void DoIfActive(GameTime gameTime)
        {
            if (timeKeeper.AsSeconds > displayDuration)
            {
                ScreenManager.SetScreen(nextScreen);
                timeKeeper.AsSeconds -= displayDuration;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (State != ScreenStates.Unloaded || State != ScreenStates.Inactive)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
                image.Draw(spriteBatch);
                spriteBatch.End();
            }
        }
    }
}
