using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class Button
{
    public readonly Mesh Mesh;
    public readonly Transform Transform;
    private readonly float _objectSize;
    private readonly ButtonAnimation _animation;

    public Button(float objectSize, Mesh mesh, Vector2 position)
    {
        Mesh = mesh;
        _objectSize = objectSize;
        Transform = new Transform()
        {
            Position = new Vector3(position.X, position.Y, 0)
        };
        
        _animation = new ButtonAnimation(Transform);
    }

    public bool IsVisible { get; private set; } = true;

    public void Update(float deltaTime)
    {
        _animation.Execute(deltaTime);
        
        if (CheckClick())
        {
            IsVisible = false;
        }

        if (CheckSpace())
        {
            IsVisible = true;
        }
    }

    private bool CheckSpace()
    {
        return WindowSettings.Keyboard.IsKeyDown(Keys.Space);
    }

    private bool CheckClick()
    {
        bool wasClicked = WindowSettings.Mouse.IsAnyButtonDown;

        if (wasClicked)
        {
            Vector2 normalizedPosition = (WindowSettings.Mouse.Position / WindowSettings.Size * 2 - Vector2.One);
            normalizedPosition.Y = -normalizedPosition.Y;
            
            Vector3 max = Transform.Position + Transform.Scale * _objectSize;
            Vector3 min = Transform.Position - Transform.Scale * _objectSize;
            wasClicked = normalizedPosition.InRange2D(min, max);
        }
        
        return wasClicked;
    }
}