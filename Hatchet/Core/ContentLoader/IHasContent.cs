using Microsoft.Xna.Framework.Content;

namespace Hatchet.ContentLoader
{
    public interface IHasOwnContent : ILoadContent
    {
        ContentManager Content { get; }
    }
}
