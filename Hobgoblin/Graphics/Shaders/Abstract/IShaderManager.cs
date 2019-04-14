namespace Hobgoblin.Graphics.Shaders.Abstract
{
    public interface IShaderManager
    {
        uint CreateShader(IShader shader);
        uint CreateShaderProgram(uint[] shaders);
    }
}
