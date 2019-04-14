using Hobgoblin.Graphics.Shaders.Abstract;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobgoblin.Graphics.Shaders.Concrete
{
    public class ShaderManager : IShaderManager
    {
        public uint CreateShader(IShader shader)
        {
            uint shaderRef = Gl.CreateShader(shader.Type);
            Gl.ShaderSource(shaderRef, shader.Source);
            Gl.CompileShader(shaderRef);

            int compiled;
            Gl.GetShader(
                shaderRef, ShaderParameterName.CompileStatus, out compiled);
            if (compiled != 0) {
                return shaderRef;
            }

            // If we reach here, the shader failed to compile.
            // Fetch the info log and throw an exception.
            Gl.DeleteShader(shaderRef);
            StringBuilder infoLog = new StringBuilder(1024);
            int logLength;

            Gl.GetShaderInfoLog(shaderRef, 1024, out logLength, infoLog);

            throw new InvalidOperationException(
                $"Unable to compile shader: {infoLog}");
        }

        public uint CreateShaderProgram(uint[] shaders)
        {
            var shaderProgramRef = Gl.CreateProgram();

            foreach (var shader in shaders) {
                Gl.AttachShader(shaderProgramRef, shader);
            }

            Gl.LinkProgram(shaderProgramRef);

            int success;
            Gl.GetProgram(
                shaderProgramRef, ProgramProperty.LinkStatus, out success);

            if (success != 0) {
                foreach(var shader in shaders) {
                    Gl.DeleteShader(shader);
                }

                return shaderProgramRef;
            }

            // If we reach here, the shader program failed to link.
            // Fetch the info log and throw an exception.
            StringBuilder infoLog = new StringBuilder(1024);
            int logLength;

            Gl.GetProgramInfoLog(
                shaderProgramRef, 1024, out logLength, infoLog);

            throw new InvalidOperationException(
                $"Unable to create shader program: {infoLog}");
        }
    }
}
