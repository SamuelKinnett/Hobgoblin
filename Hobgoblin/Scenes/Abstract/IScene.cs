using System;
using Hobgoblin.Glfw.Delegates;

namespace Hobgoblin.Scenes.Abstract
{
    public interface IScene
    {
        WindowSizeFunction WindowSizeFunction { get; }

        void Load(IntPtr window);
        void UnLoad();
        void Update();
        void Render();
    }
}
