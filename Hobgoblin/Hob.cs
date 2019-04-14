using System;
using OpenGL;

using Hobgoblin.Glfw;
using Hobgoblin.Glfw.Enums;
using Hobgoblin.Input.Abstract;
using Hobgoblin.Input.Concrete;
using Hobgoblin.Scenes.Abstract;
using Hobgoblin.Scenes.Concrete;
using Hobgoblin.Graphics.Shaders.Abstract;
using Hobgoblin.Graphics.Shaders.Concrete;
using Hobgoblin.Graphics.Shaders;
using Hobgoblin.Graphics.Primitives;

namespace Hobgoblin
{
    public class Hob : IDisposable
    {
        public ISceneManager Scenes { get; private set; }
        private const string GLFW_DLL = "libs/glfw3";

        private int windowWidth, windowHeight;
        private IntPtr window;
        private IInputManager inputManager;
        private IShaderManager shaderManager;

        private uint shaderProgram;
        private uint vao;

        private bool initialised = false;

        // TESTING
        private Triangle triangle = new Triangle(
            new Vector3(-0.5f, -0.5f, 0.0f),
                new Vector3(0.5f, -0.5f, 0.0f),
                new Vector3(0.0f, 0.5f, 0.0f));
        // END TESTING

        public Hob(int windowWidth, int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            Scenes = new SceneManager();
            inputManager = new InputManager();
            shaderManager = new ShaderManager();
        }

        public void Initialise()
        {
            Gl.Initialize();
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

            var vertexShader = shaderManager.CreateShader(
                new BasicVertexShader());
            var fragmentShader = shaderManager.CreateShader(
                new BasicFragmentShader());
            shaderProgram = shaderManager.CreateShaderProgram(
                new uint[] {
                    vertexShader,
                    fragmentShader
                });

            // Setup buffers

            vao = Gl.GenVertexArray();
            var vbo = Gl.GenBuffer();

            Gl.BindVertexArray(vao);
            Gl.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            Gl.BufferData(BufferTarget.ArrayBuffer, (uint)(4 * triangle.Vertices.Length), triangle.Vertices, BufferUsage.StaticDraw);

            Gl.VertexAttribPointer(0, 3, VertexAttribType.Float, false, 3 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);

            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
            Gl.BindVertexArray(0);

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
                    
                Gl.ClearColor(0.2f, 0.2f, 0.2f, 0.0f);
                Gl.Clear(ClearBufferMask.ColorBufferBit);

                // Drawing
                Gl.UseProgram(shaderProgram);
                Gl.BindVertexArray(vao);
                Gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
                // Scenes.CurrentScene.Render();

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
