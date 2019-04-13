using System;
using System.Collections.Generic;

using Hobgoblin.Glfw;
using Hobgoblin.Glfw.Enums.Input;
using Hobgoblin.Input.Abstract;

namespace Hobgoblin.Input.Concrete
{
    public class InputManager : IInputManager
    {
        private Dictionary<Key, bool> oldPressed;
        private Dictionary<Key, bool> currentPressed;

        public InputManager()
        {
            oldPressed = new Dictionary<Key, bool>();
            currentPressed = new Dictionary<Key, bool>();
        }

        public bool IsHeld(Key key, IntPtr window)
        {
            CheckPressed(key, window);
            return oldPressed.ContainsKey(key) 
                && oldPressed[key]
                && currentPressed[key];
        }

        public bool IsPressed(Key key, IntPtr window)
        {
            CheckPressed(key, window);

            return oldPressed.ContainsKey(key)
                ? !oldPressed[key] && currentPressed[key]
                : currentPressed[key];
        }

        public bool IsReleased(Key key, IntPtr window)
        {
            CheckPressed(key, window);

            return oldPressed.ContainsKey(key)
                ? oldPressed[key] && !currentPressed[key]
                : false;
        }

        public void Update()
        {
            foreach (var key in currentPressed.Keys) {
                oldPressed[key] = currentPressed[key];
            }
        }

        private bool CheckPressed(Key key, IntPtr window)
        {
            var pressed = GLFW.GetKey(window, key);

            currentPressed[key] = pressed;
            return pressed;
        }
    }
}
