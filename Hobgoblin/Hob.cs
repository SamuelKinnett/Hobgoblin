using System;
using OpenGL;

using Hobgoblin.Glfw;

namespace Hobgoblin
{
    public class Hob : IDisposable
    {
        private const string GLFW_DLL = "libs/glfw3";

        private int windowWidth, windowHeight;
        private IntPtr window;

        public Hob(int windowWidth, int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            GLFW.Initialise();
            window = GLFW.CreateWindow(windowWidth, windowHeight, "Test", IntPtr.Zero, IntPtr.Zero);
            GLFW.MakeContextCurrent(window);
            Gl.Initialize();
            Gl.Viewport(0, 0, windowWidth, windowHeight);
        }

        public void Run()
        {
            while(GLFW.WindowShouldClose(window) == 0) {
                Gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
                Gl.Clear(ClearBufferMask.ColorBufferBit);

                // Drawing

                GLFW.SwapBuffers(window);
                GLFW.PollEvents();
            }
        }

        public void Dispose()
        {
            GLFW.Terminate();
        }
    }
}
