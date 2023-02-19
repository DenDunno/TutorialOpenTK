using OpenTK.Windowing.Common;

public class StaticBatchingExample : IExample
{
    private RenderingObject _view = null!;

    public void Initialize()
    {
        _view = new GridView(8, 0.08f).Build();
    }

    public void Update(FrameEventArgs args)
    {
    }

    public void Render(FrameEventArgs args)
    {
        _view.Draw();
    }
}