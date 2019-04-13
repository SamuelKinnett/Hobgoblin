using System;
using System.Runtime.InteropServices;
using Hobgoblin.Glfw.Delegates;
using Hobgoblin.Glfw.Enums;

namespace Hobgoblin.Glfw
{
    /// <summary>
    /// Bindings for GLFW functions
    /// </summary>
    class GLFW
    {
        public const int DONT_CARE = -1;

        private const string GLFW_DLL = "libs/glfw3";

        // Public
        [DllImport(GLFW_DLL, EntryPoint = "glfwInit")]
        public static extern bool Init();

        [DllImport(GLFW_DLL, EntryPoint = "glfwCreateWindow")]
        public static extern IntPtr CreateWindow(
            int width, int height, string title, IntPtr monitor, IntPtr share);

        [DllImport(GLFW_DLL, EntryPoint = "glfwMakeContextCurrent")]
        public static extern void MakeContextCurrent(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwSwapBuffers")]
        public static extern void SwapBuffers(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwGetProcAddress")]
        public static extern IntPtr GetProcAddress(string procname);

        [DllImport(GLFW_DLL, EntryPoint = "glfwPollEvents")]
        public static extern void PollEvents();

        [DllImport(GLFW_DLL, EntryPoint = "glfwWindowShouldClose")]
        public static extern int WindowShouldClose(IntPtr window);

        [DllImport(GLFW_DLL, EntryPoint = "glfwTerminate")]
        public static extern void Terminate();

        [DllImport(GLFW_DLL, EntryPoint = "glfwSetWindowSizeCallback")]
        public static extern WindowSizeFunction SetWindowSizeCallback(
            IntPtr window, WindowSizeFunction cbfun);

        // Private
        [DllImport(GLFW_DLL, EntryPoint = "glfwWindowHint")]
        private static extern void WindowHint(Int32 hint, Int32 value);

        public static void WindowHint(WindowHint hint, int value)
        {
            WindowHint((Int32)hint, value);
        }

        public static void WindowHint(WindowHint hint, bool value)
        {
            WindowHint((Int32)hint, value ? 1 : 0);
        }

        public static void WindowHint(WindowHint hint, Enum value)
        {
            WindowHint((Int32)hint, (Int32)(object)value);
        }
    }
}
