using OpenTK.Mathematics;

public static class Algorithms
{
    public static Vector3 RandomVector3()
    {
        float z = Random.Shared.NextSingle() * 2.0f - 1.0f;
        float a = Random.Shared.NextSingle() * 2.0f * MathF.PI;
        float r = MathF.Sqrt(1.0f - z * z);
        float x = r * MathF.Cos(a);
        float y = r * MathF.Sin(a);

        return new Vector3(x, y, z).Normalized();
    }

    public static float RandomSignedUniform()
    {
        return Random.Shared.NextSingle() * 2 - 1;
    }

    public static int RandomSign()
    {
        return Random.Shared.Next(0, 2) == 0 ? 1 : -1;
    }

    public static Vector3 RandomVector3(float start, float end)
    {
        return new Vector3(RandomUnsigned(start, end), RandomUnsigned(start, end), RandomUnsigned(start, end));
    }
    
    public static float RandomUnsigned(float start, float end)
    {
        if (end <= start)
            throw new Exception("Start greater end in RandomSigned");
        
        float length = end - start;

        return Random.Shared.NextSingle() * length + start;
    }
    
    public static float RandomSigned(float start, float end)
    {
        return RandomUnsigned(start, end) * RandomSign();
    }

    public static float Uniform()
    {
        return Random.Shared.NextSingle();
    }
    
    public static float Lerp(float firstFloat, float secondFloat, float lerp)
    {
        float difference = secondFloat - firstFloat;
        return firstFloat + difference * lerp;
    }
    
    public static float ScaledSin(float time)
    {
        return 0.5f * MathF.Sin(time) + 0.5f;
    }
}