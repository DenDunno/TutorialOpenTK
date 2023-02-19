using OpenTK.Mathematics;

public readonly struct AnimationData
{
    public readonly Vector3 StartPosition;
    public readonly Vector3 TargetPosition;
    public readonly float TargetScale;
    public readonly float TargetAngle;

    public AnimationData(Vector3 startPosition)
    {
        StartPosition = startPosition;
        TargetPosition = startPosition + Algorithms.RandomVector3() / 4;
        TargetScale = 1 + Algorithms.RandomSigned(0f, 0.75f);
        TargetAngle = Algorithms.RandomSigned(MathF.PI / 2, 2 * MathF.PI);
    }
}