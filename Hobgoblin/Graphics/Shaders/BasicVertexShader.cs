using OpenGL;

using Hobgoblin.Graphics.Shaders.Abstract;

namespace Hobgoblin.Graphics.Shaders
{
    public class BasicVertexShader : IShader
    {
        public ShaderType Type => ShaderType.VertexShader;

        public string[] Source {
            get {
                return new string[] {
                    "#version 330 core\n",
                    "layout (location = 0) in vec3 aPos;\n",
                    "\n",
                    "void main()\n",
                    "{\n",
                    "    gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);\n",
                    "}\n"
                };
            }
        }
    }
}
