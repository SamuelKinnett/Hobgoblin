using OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hobgoblin.Graphics.Primitives
{
    public class Triangle
    {
        public float[] Vertices;
        uint vbo, vao;

        public Triangle(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            Vertices = new float[9];
            Vertices[0] = point1.X;
            Vertices[1] = point1.Y;
            Vertices[2] = point1.Z;
            Vertices[3] = point2.X;
            Vertices[4] = point2.Y;
            Vertices[5] = point2.Z;
            Vertices[6] = point3.X;
            Vertices[7] = point3.Y;
            Vertices[8] = point3.Z;

            // vao = Gl.GenVertexArray();
            // vbo = Gl.GenBuffer();
            // Gl.BindVertexArray(vao);
            // 
            // Gl.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            // Gl.BufferData(BufferTarget.ArrayBuffer, (uint)(4 * vertices.Length), vertices, BufferUsage.StaticDraw);
            // 
            // Gl.VertexAttribPointer(
            //     0, 3, VertexAttribType.Float, false, 3 * sizeof(float), 0);
            // Gl.EnableVertexAttribArray(0);
            // 
            // Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
            // Gl.BindVertexArray(0);
        }

        public void Render()
        {
            Gl.BindVertexArray(vao);
            Gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }
}
