using System;

using Hobgoblin.Glfw.Enums.Input;

namespace Hobgoblin.Input.Abstract
{
    public interface IInputManager
    {
        bool IsPressed(Key key, IntPtr window);
        bool IsHeld(Key key, IntPtr window);
        bool IsReleased(Key key, IntPtr window);
        void Update();
    }
}
