using OpenTK.Windowing.Common;

public class DynamicBatchingExample : IExample
{
    private List<Button> _buttons = new();
    private DynamicBatch _dynamicBatch = null!;
    
    public void Initialize()
    {
        _buttons = new ButtonsFactory(0.08f, 8).Create();
        
        _dynamicBatch = new("DynamicBatching/vert", "DynamicBatching/frag");
    }

    public void Update(FrameEventArgs args)
    {
        foreach (Button button in _buttons)
        {
            button.Update((float)args.Time);
        }
    }

    public void Render(FrameEventArgs args)
    {
        _dynamicBatch.Clear();
        
        foreach (Button button in _buttons)
        {
            if (button.IsVisible)
            {
                _dynamicBatch.Add(button.Mesh, button.Transform);
            }
        }
        
        _dynamicBatch.Draw();
    }
}