using System;

using Hobgoblin.Scenes.Abstract;
using Hobgoblin.Input.Abstract;
using Hobgoblin.Glfw.Enums.Input;
using Hobgoblin.Graphics.Primitives;

namespace TestApp
{
    class TestScene : Scene
    {
        private Triangle triangle;

        public override void Load(IntPtr window)
        {
            triangle = new Triangle(
                new Vector3(-0.5f, -0.5f, 0.0f),
                new Vector3(0.5f, -0.5f, 0.0f),
                new Vector3(0.0f, 0.5f, 0.0f));
        }

        public override void Render()
        {
            triangle.Render();
        }

        public override void UnLoad()
        {
        }

        public override void Update(IInputManager inputManager, IntPtr window)
        {
            if (inputManager.IsPressed(Key.Escape, window)) {
                NextScene = null;
                ChangeScene = true;
            }
        }
    }
}
