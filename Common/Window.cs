using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class Window : GameWindow
{
    private readonly FPSCounter _fpsCounter = new();
    
    public Window() : base(GameWindowSettings.Default, new NativeWindowSettings()
    {
        Vsync = VSyncMode.Adaptive, 
        Size = new Vector2i(480, 480)
    })
    {
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        
        Title = $"FPS = {_fpsCounter.Update((float)args.Time)}";
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