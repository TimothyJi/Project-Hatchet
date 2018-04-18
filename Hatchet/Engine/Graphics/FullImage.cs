using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public class FullImage : IDrawComponent
    {
        Vector2 IPositionable.Position { get => Vector2.Zero; set => throw new System.NotImplementedException(); }
        protected Vector2 _origin { get; set; }
        Vector2 IPositionable.Origin { get => _origin; set => throw new System.NotImplementedException(); }
        Vector2 IScalable.Scale { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        Rectangle? IDrawComponent.SourceRect { get => null; set => throw new System.NotImplementedException(); }
        public float Alpha { get; set; } = 1f;
        Color IDrawComponent.Color { get; set; } = Color.White;

        public bool IsActive { get; set; }
        public float Rotation { get; set; }
        SpriteEffects IDrawComponent.SpriteEffects { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        float IDrawComponent.LayerDepth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public HatchetTexture2D Texture { get; set; }
        IHatchetTexture2D ITextured.Texture { get => Texture; set => Texture = (HatchetTexture2D)value; }
        public Rectangle DestinationRectangle { get; set; } = Rectangle.Empty;
        bool IDrawComponent.UseDestinationRectangle { get => true; set => throw new System.NotImplementedException(); }
        
        Viewport viewport;
        public void Initialize(Texture2D texture, GameWindow window, Viewport viewport, bool preserveAspectRatio)
        {
            this.Texture = texture;
            this.viewport = viewport;
            window.ClientSizeChanged += (object sender, System.EventArgs args) => {
                if (preserveAspectRatio)
                {
                    float scaleWidth = this.viewport.Width / (float)Texture.Width;
                    float scaleHeight = this.viewport.Height / (float)Texture.Height;
                    float scale = MathHelper.Min(scaleHeight, scaleWidth);
                    int newWidth = (int)(Texture.Width * scale);
                    int newHeight = (int)(Texture.Height * scale);
                    DestinationRectangle = new Rectangle(this.viewport.Width / 2, this.viewport.Height / 2, newWidth, newHeight);
                }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            (this as IDrawComponent).Draw(spriteBatch);
        }
    }
}
