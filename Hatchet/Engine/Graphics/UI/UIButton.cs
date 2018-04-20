using Hatchet.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Hatchet.Graphics.UI
{
    public class UIButton : UIItem, IClickable
    {
        //public Point Padding;
        public string Text;
        public bool AlignTextToCenter { get; set; } = true;
        SpriteFont font;
        public Color TextColor { get; set; }

        RenderTarget2D renderTarget;

        public override Vector2 Position { get => base.DestinationRectangle.Location.ToVector2(); set => base.DestinationRectangle = new Rectangle(value.ToPoint(), DestinationRectangle.Size); }
        public UIButton(Texture2D background, SpriteFont font, string text, Color textColor, Point size, Vector2 position, Point padding, float layerDepth) : base(position, layerDepth)
        {
            this.Texture = background;
            this.font = font;
            //this.Padding = padding;
            this.Text = text;
            this.TextColor = textColor;
            
            if (size != Point.Zero)
                UseDestinationRectangle = true;
            DestinationRectangle = new Rectangle(position.ToPoint(), size);

            fontMeasure = font.MeasureString(Text);
            renderTarget = new RenderTarget2D(Global.GraphicsDevice, (int)MathHelper.Max(fontMeasure.X, background.Width), (int)MathHelper.Min(fontMeasure.Y, background.Height));
        }

        public event Event.ClickEvent OnClick;
        
        Rectangle clickArea;
        Vector2 fontMeasure;
        public override void Update(GameTime gameTime)
        {
            clickArea = new Rectangle((Position).ToPoint(), DestinationRectangle.Size);

            foreach (MouseInput type in Enum.GetValues(typeof(MouseInput)))
            {
                if (InputMouse.JustReleased(type) && clickArea.Contains(InputMouse.GetPosition()))
                {
                    OnClick?.Invoke(this, type);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            (this as IDrawComponent).Draw(spriteBatch);
            
            if (AlignTextToCenter)
            {
                spriteBatch.DrawString(font, Text, clickArea.Center.ToVector2() - fontMeasure*.5f, TextColor);
            } else
            {
                spriteBatch.DrawString(font, Text, Position, TextColor);
            }
        }
    }
}
