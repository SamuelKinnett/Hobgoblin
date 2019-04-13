using System;
using OpenGL;

using Hobgoblin.Glfw;
using Hobgoblin.Glfw.Enums;
using Hobgoblin.Input.Abstract;
using Hobgoblin.Input.Concrete;
using Hobgoblin.Scenes.Abstract;
using Hobgoblin.Scenes.Concrete;

namespace Hobgoblin
{
    public class Hob : IDisposable
    {
        public ISceneManager Scenes { get; private set; }
        private const string GLFW_DLL = "libs/glfw3";

        private int windowWidth, windowHeight;
        private IntPtr window;
        private IInputManager inputManager;

        private bool initialised = false;

        public Hob(int windowWidth, int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            Scenes = new SceneManager();
            inputManager = new InputManager();
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

            Gl.Viewport(0, 0, windowWidth, windowHeight);

            initialised = true;
        }

        public void Run()
        {
            if (!initialised) {
                Initialise();
            }

            Scenes.SwitchScene("MAIN", window);
            GLFW.SetWindowSizeCallback(
                window, Scenes.CurrentScene.WindowSizeFunction);

            while (GLFW.WindowShouldClose(window) == 0) {
                inputManager.Update();
                Scenes.CurrentScene.Update(inputManager, window);
                    
                Gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
                Gl.Clear(ClearBufferMask.ColorBufferBit);

                // Drawing
                Scenes.CurrentScene.Render();

                GLFW.SwapBuffers(window);
                GLFW.PollEvents();

                if (Scenes.CurrentScene.ChangeScene) {
                    if (Scenes.CurrentScene.NextScene == null) {
                        GLFW.SetWindowShouldClose(window, true);
                    } else {
                        Scenes.SwitchScene(
                            Scenes.CurrentScene.NextScene, window);
                    }
                }
            }
        }

        public void Dispose()
        {
            GLFW.Terminate();
        }
    }
}
