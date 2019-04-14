using OpenGL;

using Hobgoblin.Graphics.Shaders.Abstract;

namespace Hobgoblin.Graphics.Shaders
{
    public class BasicFragmentShader : IShader
    {
        public ShaderType Type => ShaderType.FragmentShader;

        public string[] Source {
            get {
                return new string[] {
                    "#version 330 core\n",
                    "out vec4 FragColor;\n",
                    "void main()\n",
                    "{\n",
                    "    FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);\n",
                    "}\n" };
            }
        }
    }
}
