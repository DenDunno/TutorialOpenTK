
public class MeshGeneration
{
    private readonly float _objectSize;
    private readonly int _count;
    private uint _indexOffset;
    private uint _id;

    public MeshGeneration(int count, float offset)
    {
        _count = count;
        _objectSize = (2f / count - offset) / 2;
    }
    
    public Mesh Build()
    {
        Mesh result = new();

        for (int i = 0; i < _count; ++i)
        {
            for (int j = 0; j < _count; ++j, ++_id)
            {
                if ((i + j) % 2 == 0)
                {
                    AddQuad(result);
                }
                else
                {
                    AddTriangle(result);
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
    
    private void AddQuad(Mesh mesh)
    {
        mesh.Indices.AddRange(new[]
        {
            0 + _indexOffset, 1 + _indexOffset, 2 + _indexOffset,
            2 + _indexOffset, 3 + _indexOffset, 0 + _indexOffset,
        });
        
        mesh.Vertices.AddRange(new[]
        {
            _objectSize,   _objectSize, _id, 
            _objectSize,   -_objectSize, _id, 
            -_objectSize,  -_objectSize, _id,
            -_objectSize,   _objectSize, _id,
        });

        _indexOffset += 4;
    }

    private void AddTriangle(Mesh mesh)
    {
        mesh.Indices.AddRange(new[]
        {
            0 + _indexOffset, 1 + _indexOffset, 2 + _indexOffset,
        });
        
        
        mesh.Vertices.AddRange(new[]
        {
            _objectSize, -_objectSize, _id,
            -_objectSize, -_objectSize, _id,
            0, _objectSize, _id
        });
    
        _indexOffset += 3;
    }
}