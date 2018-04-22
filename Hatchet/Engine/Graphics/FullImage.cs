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
        Rectangle IHasSourceRect.SourceRect { get => Rectangle.Empty; set => throw new System.NotImplementedException(); }
        public float Alpha { get; set; } = 1f;
        Color IDrawComponent.Color { get; set; } = Color.White;

        public bool IsActive { get; set; } = true;
        public float Rotation { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public float LayerDepth { get; set; }

        public HatchetTexture2D Texture { get; set; }
        IHatchetTexture2D ITextured.Texture { get => Texture; set => Texture = (HatchetTexture2D)value; }
        public Rectangle DestinationRectangle { get; set; } = Rectangle.Empty;
        bool IDrawComponent.UseDestinationRectangle { get => true; set => throw new System.NotImplementedException(); }
        
        bool preserveAspect;
        public void Initialize(Texture2D texture, bool preserveAspectRatio, float layerDepth)
        {
            this.Texture = texture;
            this.LayerDepth = layerDepth;
            this.preserveAspect = preserveAspectRatio;

            _origin = texture.Bounds.Center.ToVector2();

            OnClientSizeChanged(this, System.EventArgs.Empty);
            Global.Window.ClientSizeChanged += OnClientSizeChanged;
        }

        private void OnClientSizeChanged(object sender, System.EventArgs args)
        {
            Viewport viewport = Global.Viewport;
            if (preserveAspect)
            {
                float scaleWidth = viewport.Width / (float)Texture.Width;
                float scaleHeight = viewport.Height / (float)Texture.Height;
                float scale = MathHelper.Min(scaleHeight, scaleWidth);
                int newWidth = (int)(Texture.Width * scale);
                int newHeight = (int)(Texture.Height * scale);
                DestinationRectangle = new Rectangle(viewport.Width / 2, viewport.Height / 2, newWidth, newHeight);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            (this as IDrawComponent).Draw(spriteBatch);
        }
    }
}
