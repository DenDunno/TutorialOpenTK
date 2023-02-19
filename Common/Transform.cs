using OpenTK.Mathematics;

public class Transform
{
    public Vector3 Scale = Vector3.One;
    public Vector3 Position = Vector3.Zero;
    public Quaternion Rotation = Quaternion.Identity;

    public Matrix4 ModelMatrix => Matrix4.CreateScale(Scale) * 
                                  Matrix4.CreateFromQuaternion(Rotation) * 
                                  Matrix4.CreateTranslation(Position);
}