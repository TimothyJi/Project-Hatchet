using Microsoft.Xna.Framework.Input;

namespace Hatchet.Input
{
    public struct InputManager : IInputManager
    {
        public GenericInputManager<KeyboardState> Keyboard { get; private set; }
        IGenericInputManager<KeyboardState> IInputManager.Keyboard => Keyboard;

        public GenericInputManager<MouseState> Mouse { get; private set; }
        IGenericInputManager<MouseState> IInputManager.Mouse => Mouse;

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            Keyboard.Update(keyboardState);
            Mouse.Update(mouseState);
        }
    }

    public static class InputManagerExtensions
    {
        public static bool IsDown(this IGenericInputManager<KeyboardState> k, Keys key) => k.State.IsKeyDown(key);
        public static bool IsUp(this IGenericInputManager<KeyboardState> k, Keys key) => k.State.IsKeyUp(key);
        public static bool JustPressed(this IGenericInputManager<KeyboardState> k, Keys key) => k.PreviousState.IsKeyUp(key) && k.State.IsKeyDown(key);
        public static bool JustReleased(this IGenericInputManager<KeyboardState> k, Keys key) => k.PreviousState.IsKeyDown(key) && k.State.IsKeyUp(key);
    }
}
