using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class Window : GameWindow
{
    public Window() : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = new Vector2i(480, 445) })
    {
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.ClearColor(Color4.Black);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        base.OnRenderFrame(args);
        SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Size.X, Size.Y);
    }
}