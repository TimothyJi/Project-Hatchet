using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public interface IPositionable
    {
        Vector2 Position { get; set; }
        Vector2 Origin { get; set; }
    }
}