using System;
using OpenGL;

using Hobgoblin.Glfw;
using Hobgoblin.Glfw.Enums;

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
        }

        public void Initialise()
        {
            GLFW.Init();
            GLFW.WindowHint(WindowHint.ContextVersionMajor, 3);
            GLFW.WindowHint(WindowHint.ContextVersionMinor, 3);
            GLFW.WindowHint(
                WindowHint.OpenGLProfile, OpenGLProfile.OpenGlCoreProfile);

            window = GLFW.CreateWindow(
                windowWidth,
                windowHeight,
                "Test",
                IntPtr.Zero,
                IntPtr.Zero);

            if (window == null) {
                throw new Exception("Failed to create a GLFW window");
            }

            GLFW.MakeContextCurrent(window);

            GLFW.SetWindowSizeCallback(window, ResizeTest);

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

        public void ResizeTest(IntPtr window, int windowWidth, int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            Gl.Viewport(0, 0, windowWidth, windowHeight);
        }
    }
}
