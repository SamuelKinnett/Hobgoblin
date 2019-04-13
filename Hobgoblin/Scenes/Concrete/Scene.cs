using System;
using System.Collections.Generic;
using System.Text;

using OpenGL;

using Hobgoblin.Glfw.Delegates;
using Hobgoblin.Scenes.Abstract;

namespace Hobgoblin.Scenes.Concrete
{
    public class Scene : IScene
    {
        public WindowSizeFunction WindowSizeFunction => Resize;

        public virtual void Load(IntPtr window)
        {
        }

        public virtual void Render()
        {
        }

        public virtual void UnLoad()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Resize(
            IntPtr window, int windowWidth, int windowHeight)
        {
            Gl.Viewport(0, 0, windowWidth, windowHeight);
        }
    }
}
