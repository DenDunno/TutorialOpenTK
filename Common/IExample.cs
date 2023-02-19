using OpenTK.Windowing.Common;

public interface IExample
{
    void Initialize();
    void Update(FrameEventArgs args);
    void Render(FrameEventArgs args);
}