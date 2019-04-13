using System;

using Hobgoblin.Glfw.Delegates;
using Hobgoblin.Input.Abstract;

namespace Hobgoblin.Scenes.Abstract
{
    public interface IScene
    {
        WindowSizeFunction WindowSizeFunction { get; }
        string NextScene { get; }
        bool ChangeScene { get; }

        void Load(IntPtr window);
        void UnLoad();
        void Update(IInputManager inputManager, IntPtr window);
        void Render();
    }
}
