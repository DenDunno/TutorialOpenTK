using OpenTK.Mathematics;

public class ButtonAnimation
{
    private readonly Transform _transform;
    private readonly float _startRotation;
    private readonly float _targetRotation;
    private readonly float _speed = 3f;
    private float _time;

    public ButtonAnimation(Transform transform)
    {
        _transform = transform;
        _startRotation = Algorithms.RandomSigned(0, MathF.PI / 2);
        _targetRotation = _startRotation + Algorithms.RandomSigned(MathF.PI / 4, MathF.PI / 2);
    }
    
    public void Execute(float deltaTime)
    {
        _time += deltaTime;
        float lerp = MathF.Sin(_time * _speed);
        float rotationAngle = Algorithms.Lerp(_startRotation, _targetRotation, lerp);
        _transform.Rotation = Quaternion.FromAxisAngle(Vector3.UnitZ, rotationAngle);
    }
}