﻿using Hatchet.ContentLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.Screen
{
    public interface IScreen : IHasOwnContent
    {
        IScreenManager ScreenManager { get; }

        ScreenStates State { get; set; }

        void Initialize(IScreenManager manager);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
