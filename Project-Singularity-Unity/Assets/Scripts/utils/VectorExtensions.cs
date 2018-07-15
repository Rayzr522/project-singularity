using UnityEngine;

static class VectorExtensions
{
    /// <summary>
    /// Converts a Vector2 to a Vector3 by adding a Z component of the given value.
    /// </summary>
    public static Vector3 to3D(this Vector2 self, float z)
    {
        return new Vector3(self.x, self.y, z);
    }

    /// <summary>
    /// Converts a Vector2 to a Vector3 by adding a Z component of zero.
    /// </summary>
    public static Vector3 to3D(this Vector2 self)
    {
        return self.to3D(0);
    }

    /// <summary>
    /// Converts a Vector3 to a Vector2 by removing the Z component.
    /// </summary>
    public static Vector2 to2D(this Vector3 self)
    {
        return new Vector2(self.x, self.y);
    }
}