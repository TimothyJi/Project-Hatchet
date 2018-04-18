using Hatchet.Graphics.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet
{
    public static class Global
    {
        public static GraphicsDevice GraphicsDevice { get; internal set; }
        public static Viewport Viewport => GraphicsDevice.Viewport;
        public static GameWindow Window { get; internal set; }
    }

    public abstract class HatchetGame : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        protected ScreenManager screenManager;
        
        public HatchetGame()
        {
            graphics = new GraphicsDeviceManager(this);
            screenManager = new ScreenManager();
            Content.RootDirectory = "Content";

            Global.Window = Window;
            Global.GraphicsDevice = GraphicsDevice;
        }

        public HatchetGame(string contentRoot)
        {
            graphics = new GraphicsDeviceManager(this);
            screenManager = new ScreenManager();
            Content.RootDirectory = contentRoot;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            screenManager.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            screenManager.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            screenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected void Draw(GameTime gameTime, bool clear)
        {
            if (clear)
                GraphicsDevice.Clear(Color.Transparent);

            base.Draw(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
