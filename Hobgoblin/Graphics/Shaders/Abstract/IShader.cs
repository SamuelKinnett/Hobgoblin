using OpenGL;

namespace Hobgoblin.Graphics.Shaders.Abstract
{
    public interface IShader
    {
        ShaderType Type { get; }
        string[] Source { get; }
    }
}
