using UnityEngine;

public class OtherFunctions 
{
    public static float getMaxElement(Vector3 v3)
    {
        return Mathf.Max(Mathf.Max(v3.x, v3.y), v3.z);
    }
}
