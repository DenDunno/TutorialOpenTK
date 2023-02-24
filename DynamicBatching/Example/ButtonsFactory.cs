using OpenTK.Mathematics;

public class ButtonsFactory
{
    private readonly float _step;
    private readonly int _gridSize;
    private readonly float _objectSize;
    private readonly List<VertexAttribute> _attributes = new()
    {
        new VertexAttribute(0, 2, 24, 0), // position
        new VertexAttribute(1, 4, 24, 8), // color
    };

    private readonly Vector4[] _colors = 
    {
        new(1, 0.5f, 0, 1), 
        new(0.5f, 0, 1, 1),
        new(1, 0, 0.75f, 1), 
        new(0.25f, 0.9f, 0.5f, 1),
        new(1, 1, 0.25f, 1),  
        new(0, 1, 1, 1), 
    };

    public ButtonsFactory(float step, int gridSize)
    {
        _step = step;
        _gridSize = gridSize;
        _objectSize = (2f / gridSize - _step) / 2;
    }

    public List<Button> Create()
    {
        List<Button> buttons = new();
        
        for (int rowIndex = 0; rowIndex < _gridSize; ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < _gridSize; ++columnIndex)
            {
                Vector4 color = _colors[(rowIndex * _gridSize + columnIndex) % _colors.Length];
                Mesh mesh = (rowIndex + columnIndex) % 2 == 0 ? CreateQuad(color) : CreateTriangle(color);

                buttons.Add(new Button(_objectSize, mesh, new Vector2
                {
                    X = -1 + columnIndex * (_objectSize * 2 + _step) + _objectSize + _step / 2,
                    Y = -1 + rowIndex * (_objectSize * 2 + _step) + _objectSize + _step / 2,
                }));
            }
        }

        return buttons;
    }

    private Mesh CreateQuad(Vector4 color)
    {
        return new()
        {
            Vertices =
            {
                _objectSize, _objectSize, color.X, color.Y, color.Z, color.W,
                _objectSize, -_objectSize, color.X, color.Y, color.Z, color.W,
                -_objectSize, -_objectSize, color.X, color.Y, color.Z, color.W,
                -_objectSize, _objectSize, color.X, color.Y, color.Z, color.W,
            },

            Indices =
            {
                0, 1, 2,
                2, 3, 0,
            },
            
            Attributes = _attributes
        };
    }
    
    private Mesh CreateTriangle(Vector4 color)
    {
        return new()
        {
            Vertices =
            {
                _objectSize, -_objectSize, color.X, color.Y, color.Z, color.W,
                -_objectSize, -_objectSize, color.X, color.Y, color.Z, color.W,
                0, _objectSize, color.X, color.Y, color.Z, color.W,
            },

            Indices =
            {
                0, 1, 2,
            },
            
            Attributes = _attributes
        };
    }
}