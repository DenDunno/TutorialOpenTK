using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class AnimatedGrid
{
    private readonly float[] _rawModelMatrices;
    private readonly Transform[] _transforms;
    private readonly int _shaderProgramId;
    private readonly AnimationData[] _animationData;
    private float _time;

    public AnimatedGrid(int shaderProgramId, int count, float offset)
    {
        _shaderProgramId = shaderProgramId;
        _transforms = SetupTransforms(count, offset * 2);
        _animationData = SetupAnimationData(count);
        _rawModelMatrices = new float[16 * count * count];
    }

    public void SetColorsToShader()
    {
        int countIndex = GL.GetUniformLocation(_shaderProgramId, "colorsCount");
        int colorsIndex = GL.GetUniformLocation(_shaderProgramId, "colors");
        
        GL.UseProgram(_shaderProgramId);
        GL.Uniform1(countIndex, 6);
        GL.Uniform4(colorsIndex, 6, new float[]
        {
            255, 255, 0, 255, // yellow
            0, 255, 255, 255, // cyan
            255, 0, 255, 255, // purple
            255, 0, 0, 255,   // red
            0, 255, 0, 255,   // green
            0, 0, 255, 255,   // blue
        });
    }

    private Transform[] SetupTransforms(int count, float offset)
    {
        Transform[] modelMatrices = new Transform[count * count];
        float objectSize = (2f / count - offset) / 2;
        
        for (int i = 0; i < count; ++i)
        {
            for (int j = 0; j < count; ++j)
            {
                modelMatrices[i * count + j] = new Transform()
                {
                    Position = new Vector3()
                    {
                        X = -1 + j * (objectSize * 2 + offset) + objectSize + offset / 2,
                        Y = -1 + i * (objectSize * 2 + offset) + objectSize + offset / 2,
                        Z = 0,
                    }
                };
            }
        }

        return modelMatrices;
    }

    private AnimationData[] SetupAnimationData(int count)
    {
        AnimationData[] result = new AnimationData[count * count];

        for (int i = 0; i < result.Length; ++i)
        {
            result[i] = new AnimationData(_transforms[i].Position);
        }

        return result;
    }

    public void Update(float deltaTime)
    {
        UpdateMatrices(deltaTime);
        MapData();
        SendDataToShader();
    }

    private void UpdateMatrices(float deltaTime)
    {
        _time += deltaTime;
        float lerp = Algorithms.ScaledSin(_time * 2);
            
        for (int i = 0; i < _transforms.Length; ++i)
        {
            Vector3 eulerAngles = Vector3.Lerp(Vector3.Zero, Vector3.UnitZ * _animationData[i].TargetAngle, lerp);
            
            _transforms[i].Rotation = Quaternion.FromEulerAngles(eulerAngles);
            _transforms[i].Position = Vector3.Lerp(_animationData[i].StartPosition, _animationData[i].TargetPosition, lerp);
            _transforms[i].Scale = Algorithms.Lerp(1, _animationData[i].TargetScale, lerp) * Vector3.One;
        }
    }

    private void MapData()
    {
        for (int i = 0; i < _transforms.Length; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                for (int k = 0; k < 4; ++k)
                {
                    Matrix4 modelMatrix = _transforms[i].ModelMatrix;
                    _rawModelMatrices[i * 16 + j * 4 + k] = modelMatrix[j, k];
                }
            }
        }
    }

    private void SendDataToShader()
    {
        int location = GL.GetUniformLocation(_shaderProgramId, "modelMatrices");
        GL.ProgramUniformMatrix4(_shaderProgramId, location, _rawModelMatrices.Length / 16, true, _rawModelMatrices);
    }
}