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

        public Point Size { get => DestinationRectangle.Size; set => DestinationRectangle = new Rectangle(DestinationRectangle.Location, value); }
        
        public Rectangle DisplayArea;
        Vector2 textPosition;
        public override Vector2 Position { get => base.DestinationRectangle.Location.ToVector2(); set => base.DestinationRectangle = new Rectangle(value.ToPoint(), DestinationRectangle.Size); }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="background"></param>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="position"></param>
        /// <param name="padding">Does nothing as of now.</param>
        /// <param name="layerDepth"></param>
        public UIButton(Texture2D background, SpriteFont font, string text, Color textColor, Vector2 position, Point padding, float layerDepth) : base(position, layerDepth)
        {
            this.Texture = background;
            this.font = font;
            //this.Padding = padding;
            this.Text = text;
            this.TextColor = textColor;
            this.Position = position;

            UseDestinationRectangle = true;
            Recalculate();
        }

        public void Recalculate()
        {
            Vector2 fontMeasure = font.MeasureString(Text);

            UseDestinationRectangle = Size != Point.Zero;
            DestinationRectangle = new Rectangle(Position.ToPoint(), Size);

            DisplayArea = new Rectangle((Position - Origin).ToPoint(), DestinationRectangle.Size);
            textPosition = AlignTextToCenter ? DisplayArea.Center.ToVector2() - fontMeasure * .5f : Position;
        }

        public event Event.ClickEvent OnClick;
        
        public override void Update(GameTime gameTime)
        {
            if (Size != DisplayArea.Size)
                Recalculate();

            foreach (MouseInput type in Enum.GetValues(typeof(MouseInput)))
            {
                if (InputMouse.JustReleased(type) && DisplayArea.Contains(InputMouse.GetPosition()))
                {
                    OnClick?.Invoke(this, type);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            (this as IDrawComponent).Draw(spriteBatch);
            spriteBatch.DrawString(font, Text, textPosition, TextColor, Rotation, Vector2.Zero, Scale, SpriteEffects, LayerDepth);
        }
    }
}
