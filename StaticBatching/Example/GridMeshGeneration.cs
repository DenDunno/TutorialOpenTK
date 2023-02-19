using OpenTK.Mathematics;

public class GridMeshGeneration
{
    private readonly float _objectSize;
    private readonly float _offset;
    private readonly int _count;
    private uint _indexOffset;
    private uint _id;
    
    public GridMeshGeneration(int count, float offset)
    {
        _count = count;
        _offset = offset;
        _objectSize = 2f / count - _offset;
    }
    
    public Mesh Build()
    {
        Mesh result = new();

        for (int i = 0; i < _count; ++i)
        {
            for (int j = 0; j < _count; ++j, ++_id)
            {
                Vector2 position = GetPositionForObject(i, j);

                if ((i + j) % 2 == 0)
                {
                    AddQuad(result, position);
                }
                else
                {
                    AddTriangle(result, position);
                }
            }
        }
        
        result.Attributes.AddRange(new VertexAttribute[]
        {
            new(0, 2, 12, 0),
            new(1, 1, 12, 8),
        });

        return result;
    }

    private Vector2 GetPositionForObject(int i, int j)
    {
        return new()
        {
            X = -1 + _offset / 2 + j * (_objectSize + _offset),
            Y = -1 + _offset / 2 + i * (_objectSize + _offset)
        };
    }

    private void AddQuad(Mesh mesh, Vector2 position)
    {
        mesh.Indices.AddRange(new[]
        {
            0 + _indexOffset, 1 + _indexOffset, 2 + _indexOffset,
            2 + _indexOffset, 3 + _indexOffset, 0 + _indexOffset,
        });
        
        mesh.Vertices.AddRange(new[]
        {
            position.X + _objectSize,   position.Y, _id, 
            position.X + _objectSize,   position.Y + _objectSize, _id, 
            position.X,   position.Y + _objectSize, _id,
            position.X,   position.Y, _id,
        });

        _indexOffset += 4;
    }

    private void AddTriangle(Mesh mesh, Vector2 position)
    {
        mesh.Indices.AddRange(new[]
        {
            0 + _indexOffset, 1 + _indexOffset, 2 + _indexOffset,
        });
        
        mesh.Vertices.AddRange(new[]
        {
            position.X,   position.Y, _id,
            position.X + _objectSize,   position.Y, _id, 
            position.X + _objectSize / 2f,   position.Y + _objectSize, _id
        });
    
        _indexOffset += 3;
    }
}