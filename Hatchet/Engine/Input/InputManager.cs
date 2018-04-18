using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hatchet.Input
{
    public class InputManager<TInputState>
    {
        public static TInputState PreviousState { get; set; }
        public static TInputState State { get; set; }

        public static void Update(TInputState newState)
        {
            PreviousState = State;
            State = newState;
        }
    }

    public static class InputManager_KeyboardState_Extensions
    {
        public static bool IsHeld(this InputManager<KeyboardState> k, Keys key) => InputManager<KeyboardState>.State.IsKeyDown(key);
        public static bool JustPressed(this InputManager<KeyboardState> k, Keys key) => InputManager<KeyboardState>.PreviousState.IsKeyUp(key) && InputManager<KeyboardState>.State.IsKeyDown(key);
        public static bool JustReleased(this InputManager<KeyboardState> k, Keys key) => InputManager<KeyboardState>.PreviousState.IsKeyDown(key) && InputManager<KeyboardState>.State.IsKeyUp(key);
    }
    
    public static class InputManager_MouseState_Extensions {
        public static bool IsPressed(this InputManager<MouseState> i, MouseInput input)
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
        public static bool JustPressed(this InputManager<MouseState> i, MouseInput input)
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
        public static bool JustReleased(this InputManager<MouseState> i, MouseInput input)
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
        public static Point GetPosition(this InputManager<MouseState> i) => InputManager<MouseState>.State.Position;
        public static int GetScroll(this InputManager<MouseState> i) => InputManager<MouseState>.PreviousState.ScrollWheelValue - InputManager<MouseState>.State.ScrollWheelValue;
        public static bool HasMouseMoved(this InputManager<MouseState> i) => InputManager<MouseState>.PreviousState.Position != InputManager<MouseState>.State.Position;
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
