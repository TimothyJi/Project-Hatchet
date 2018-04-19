using Hatchet.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Hatchet.Graphics.UI
{
    public class UIButton : UIItem, IClickable
    {
        Point padding;
        string text;
        SpriteFont font;
        Color textColor;
        public UIButton(Texture2D background, SpriteFont font, string text, Color textColor, Point size, Vector2 position, Point padding, float layerDepth) : base(position, layerDepth)
        {
            this.Texture = background;
            this.font = font;
            this.padding = padding;
            this.text = text;
            this.textColor = textColor;

            UseDestinationRectangle = true;
            DestinationRectangle = new Rectangle(position.ToPoint(), size);
        }

        public event Event.ClickEvent OnClick;

        int t = 0;
        Rectangle clickArea;
        public override void Update(GameTime gameTime)
        {
            clickArea = new Rectangle((Origin - Position).ToPoint(), Texture.Bounds.Size);

            foreach (MouseInput type in Enum.GetValues(typeof(MouseInput)))
            {
                if (InputMouse.JustReleased(type))
                {
                    OnClick?.Invoke(this, type);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            (this as IDrawComponent).Draw(spriteBatch);

            //draw text.
            spriteBatch.DrawString(font, text, new Vector2(clickArea.Right, clickArea.Center.Y) + padding.ToVector2(), textColor);
        }
    }
}
