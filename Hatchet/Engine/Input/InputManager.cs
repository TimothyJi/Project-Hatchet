using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hatchet.Input
{
    public static class InputManager<TInputState>
    {
        public static TInputState PreviousState { get; set; }
        public static TInputState State { get; set; }

        public static void Update(TInputState newState)
        {
            PreviousState = State;
            State = newState;
        }
    }

    public class InputKeyboard
    {
        public static bool IsHeld(Keys key) => InputManager<KeyboardState>.State.IsKeyDown(key);
        public static bool JustPressed(Keys key) => InputManager<KeyboardState>.PreviousState.IsKeyUp(key) && InputManager<KeyboardState>.State.IsKeyDown(key);
        public static bool JustReleased(Keys key) => InputManager<KeyboardState>.PreviousState.IsKeyDown(key) && InputManager<KeyboardState>.State.IsKeyUp(key);
    }
    public class InputMouse {
        public static bool IsPressed(MouseInput input)
        {
            switch (input)
            {
                case MouseInput.LeftButton:
                    return InputManager<MouseState>.State.LeftButton == ButtonState.Pressed;
                case MouseInput.MiddleButton:
                    return InputManager<MouseState>.State.MiddleButton == ButtonState.Pressed;
                case MouseInput.RightButton:
                    return InputManager<MouseState>.State.RightButton == ButtonState.Pressed;
                case MouseInput.XButton1:
                    return InputManager<MouseState>.State.XButton1 == ButtonState.Pressed;
                case MouseInput.XButton2:
                    return InputManager<MouseState>.State.XButton2 == ButtonState.Pressed;

                default:
                    return false;
            }
        }
        public static bool JustPressed(MouseInput input)
        {
            switch (input)
            {
                case MouseInput.LeftButton:
                    return InputManager<MouseState>.State.LeftButton == ButtonState.Pressed && InputManager<MouseState>.PreviousState.LeftButton == ButtonState.Released;
                case MouseInput.MiddleButton:
                    return InputManager<MouseState>.State.MiddleButton == ButtonState.Pressed && InputManager<MouseState>.PreviousState.MiddleButton == ButtonState.Released;
                case MouseInput.RightButton:
                    return InputManager<MouseState>.State.RightButton == ButtonState.Pressed && InputManager<MouseState>.PreviousState.RightButton == ButtonState.Released;
                case MouseInput.XButton1:
                    return InputManager<MouseState>.State.XButton1 == ButtonState.Pressed && InputManager<MouseState>.PreviousState.XButton1 == ButtonState.Released;
                case MouseInput.XButton2:
                    return InputManager<MouseState>.State.XButton2 == ButtonState.Pressed && InputManager<MouseState>.PreviousState.XButton2 == ButtonState.Released;

                default:
                    return false;
            }
        }
        public static bool JustReleased(MouseInput input)
        {
            switch (input)
            {
                case MouseInput.LeftButton:
                    return InputManager<MouseState>.State.LeftButton == ButtonState.Released && InputManager<MouseState>.PreviousState.LeftButton == ButtonState.Pressed;
                case MouseInput.MiddleButton:
                    return InputManager<MouseState>.State.MiddleButton == ButtonState.Released && InputManager<MouseState>.PreviousState.MiddleButton == ButtonState.Pressed;
                case MouseInput.RightButton:
                    return InputManager<MouseState>.State.RightButton == ButtonState.Released && InputManager<MouseState>.PreviousState.RightButton == ButtonState.Pressed;
                case MouseInput.XButton1:
                    return InputManager<MouseState>.State.XButton1 == ButtonState.Released && InputManager<MouseState>.PreviousState.XButton1 == ButtonState.Pressed;
                case MouseInput.XButton2:
                    return InputManager<MouseState>.State.XButton2 == ButtonState.Released && InputManager<MouseState>.PreviousState.XButton2 == ButtonState.Pressed;

                default:
                    return false;
            }
        }
        public static Point GetPosition() => InputManager<MouseState>.State.Position;
        public static int GetScroll() => InputManager<MouseState>.PreviousState.ScrollWheelValue - InputManager<MouseState>.State.ScrollWheelValue;
        public static bool HasMouseMoved() => InputManager<MouseState>.PreviousState.Position != InputManager<MouseState>.State.Position;
    }
}
