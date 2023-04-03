using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoundsExtension
{
    public static bool Contains(this Bounds bounds, Bounds check)
    {
        return bounds.Contains(check.min) && bounds.Contains(check.max);
    }

    public static bool Intersects(this Bounds bounds, Vector3 center, float radius)
    {
        var target = Vector3.zero;

        target.x = Mathf.Clamp(center.x, bounds.min.x, bounds.max.x);
        target.y = Mathf.Clamp(center.y, bounds.min.y, bounds.max.y);
        target.z = Mathf.Clamp(center.z, bounds.min.z, bounds.max.z);

        return (center - target).sqrMagnitude < radius * radius;
    }
}
