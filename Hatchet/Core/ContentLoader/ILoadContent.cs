using Microsoft.Xna.Framework.Content;

namespace Hatchet.ContentLoader
{
    public interface ILoadContent {
        void LoadContent(ContentManager content);
        void UnloadContent();
    }
}
