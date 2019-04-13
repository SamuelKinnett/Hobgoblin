using System;

using OpenGL;

using Hobgoblin.Glfw.Delegates;
using Hobgoblin.Input.Abstract;

namespace Hobgoblin.Scenes.Abstract
{
    public abstract class Scene : IScene
    {
        public WindowSizeFunction WindowSizeFunction => Resize;
        public string NextScene { get; set; }
        public bool ChangeScene { get; set; }

        public Scene()
        {
            NextScene = "";
            ChangeScene = false;
        }

        public abstract void Load(IntPtr window);
        public abstract void Render();
        public abstract void UnLoad();
        public abstract void Update(IInputManager inputManager, IntPtr window);

        public virtual void Resize(
            IntPtr window, int windowWidth, int windowHeight)
        {
            Gl.Viewport(0, 0, windowWidth, windowHeight);
        }
    }
}
