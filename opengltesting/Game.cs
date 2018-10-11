using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace opengltesting
{
    class Game
    {
        double theta;
        GameWindow window;
        public Game(GameWindow window)
        {

            this.window = window;

            Start();
        }
        void Start()
        {
            window.Load += loaded;
            window.Resize += resized;
            window.RenderFrame += renderF;
            
            window.Run(1.0 / 60.0);
        }

        void resized(object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(80), window.Width/window.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(0.0f, 0.0f, -45.0f);
            GL.Rotate(theta, 5, 0, 0);
            GL.Rotate(theta, 5, 0, 5);
            GL.Rotate(theta, 0, 5, 0);
            GL.Scale(1, 1, 1);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(10.0, -10.0, 10.0);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.End();

            window.SwapBuffers();

            theta += 1;
        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0,0,0,0);

            GL.Enable(EnableCap.DepthTest);
        }
    }
}
