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

            Global.Window = Window;
            Global.GraphicsDevice = GraphicsDevice;
        }

        protected override void LoadContent()
        {
            spriteBatch = spriteBatch ?? new SpriteBatch(GraphicsDevice);
            screenManager.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            screenManager.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (EXIT)
                Exit();

            screenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            screenManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        private static bool EXIT;
        public static void ExitApp() => EXIT = true;
    }
}
