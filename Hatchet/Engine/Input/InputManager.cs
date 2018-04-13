using Microsoft.Xna.Framework;
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
        public static bool IsHeld(this IGenericInputManager<KeyboardState> k, Keys key) => k.State.IsKeyDown(key);
        public static bool JustPressed(this IGenericInputManager<KeyboardState> k, Keys key) => k.PreviousState.IsKeyUp(key) && k.State.IsKeyDown(key);
        public static bool JustReleased(this IGenericInputManager<KeyboardState> k, Keys key) => k.PreviousState.IsKeyDown(key) && k.State.IsKeyUp(key);

        public static bool IsPressed(this IGenericInputManager<MouseState> m, MouseInput input)
        {
            switch (input)
            {
                case MouseInput.LeftButton:
                    return m.State.LeftButton == ButtonState.Pressed;
                case MouseInput.MiddleButton:
                    return m.State.MiddleButton == ButtonState.Pressed;
                case MouseInput.RightButton:
                    return m.State.RightButton == ButtonState.Pressed;
                case MouseInput.XButton1:
                    return m.State.XButton1 == ButtonState.Pressed;
                case MouseInput.XButton2:
                    return m.State.XButton2 == ButtonState.Pressed;

                default:
                    return false;
            }
        }
        public static bool JustPressed(this IGenericInputManager<MouseState> m, MouseInput input)
        {
            switch (input)
            {
                case MouseInput.LeftButton:
                    return m.State.LeftButton == ButtonState.Pressed && m.PreviousState.LeftButton == ButtonState.Released;
                case MouseInput.MiddleButton:
                    return m.State.MiddleButton == ButtonState.Pressed && m.PreviousState.MiddleButton == ButtonState.Released;
                case MouseInput.RightButton:
                    return m.State.RightButton == ButtonState.Pressed && m.PreviousState.RightButton == ButtonState.Released;
                case MouseInput.XButton1:
                    return m.State.XButton1 == ButtonState.Pressed && m.PreviousState.XButton1 == ButtonState.Released;
                case MouseInput.XButton2:
                    return m.State.XButton2 == ButtonState.Pressed && m.PreviousState.XButton2 == ButtonState.Released;

                default:
                    return false;
            }
        }
        public static bool JustReleased(this IGenericInputManager<MouseState> m, MouseInput input)
        {
            switch (input)
            {
                case MouseInput.LeftButton:
                    return m.State.LeftButton == ButtonState.Released && m.PreviousState.LeftButton == ButtonState.Pressed;
                case MouseInput.MiddleButton:
                    return m.State.MiddleButton == ButtonState.Released && m.PreviousState.MiddleButton == ButtonState.Pressed;
                case MouseInput.RightButton:
                    return m.State.RightButton == ButtonState.Released && m.PreviousState.RightButton == ButtonState.Pressed;
                case MouseInput.XButton1:
                    return m.State.XButton1 == ButtonState.Released && m.PreviousState.XButton1 == ButtonState.Pressed;
                case MouseInput.XButton2:
                    return m.State.XButton2 == ButtonState.Released && m.PreviousState.XButton2 == ButtonState.Pressed;

                default:
                    return false;
            }
        }
        public static Point GetPosition(this IGenericInputManager<MouseState> m) => m.State.Position;
        public static int GetScroll(this IGenericInputManager<MouseState> m) => m.PreviousState.ScrollWheelValue - m.State.ScrollWheelValue;   
        public static bool HasMouseMoved(this IGenericInputManager<MouseState> m) => m.PreviousState.Position != m.State.Position;
    }

    public enum MouseInput
    {
        LeftButton,
        MiddleButton,
        RightButton,
        /// <summary>
        /// Side Button 1
        /// </summary>
        XButton1,
        /// <summary>
        /// Side Button 2
        /// </summary>
        XButton2
    }
}
