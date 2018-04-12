using Microsoft.Xna.Framework.Input;

namespace Hatchet.Input
{
    public interface IInputManager
    {
        IGenericInputManager<KeyboardState> Keyboard { get; }
        IGenericInputManager<MouseState> Mouse { get; }

        void Update(KeyboardState keyboardState, MouseState mouseState);
    }
}
