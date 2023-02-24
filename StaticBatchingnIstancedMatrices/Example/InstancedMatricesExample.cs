using OpenTK.Windowing.Common;

public class InstancedMatricesExample : IExample
{
    private RenderingObject _view = null!;
    private AnimatedGrid _animatedGrid = null!;
    private readonly int _elementsCount = 8;
    private readonly float _offset = 0.08f;
    
    public void Initialize()
    {
        Mesh mesh = new MeshGeneration(_elementsCount, _offset).Build();
        _view = new RenderingObject("StaticBatchingInstancedMatrices/vert", "StaticBatchingInstancedMatrices/frag");
        _view.BufferData(mesh);
        _animatedGrid = new AnimatedGrid(_view.ShaderProgramId, _elementsCount, _offset);
        _animatedGrid.SetColorsToShader();
    }

    public void Update(FrameEventArgs args)
    {
        _animatedGrid.Update((float)args.Time);
    }

    public void Render(FrameEventArgs args)
    {
        _view.Draw();
    }
}