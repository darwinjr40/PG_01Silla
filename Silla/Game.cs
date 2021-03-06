
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Drawing;
namespace Silla
{
    class Game : GameWindow
    {
        Pata p = new Pata(0, 0, 0);//espalda
        Mesa m = new Mesa(-10, -10, 0, 10, 10, 15);
        public Game(int ancho, int alto, string titulo)
             : base(ancho, alto, GraphicsMode.Default, titulo){}

        protected override void OnResize(EventArgs e)//Esta función se ejecuta cada vez que se cambia el tamaño de la ventana.
        {   
            base.OnResize(e);
            GL.Viewport(0, 0, base.Width, base.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            int v = 50;
            GL.Ortho(-v, v, -v, v, -v, 10*v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        
        protected override void OnRenderFrame(FrameEventArgs e)//ejecuta 60 hz
        {
            base.OnRenderFrame(e); 
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);//limpia el dibujo 

            m.draw();
            p.draw();

            base.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
         }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(1.8f, 1, 3, 0);
            GL.Enable(EnableCap.DepthTest);//nuevo
        }

      

       
    }
}
