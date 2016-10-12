using UnityEngine;
class MouseLook
{

    // This is the function from the standard assets FPS controller, I don't understand quaternions...
    public static Quaternion ClampRotationAroundXAxis(Quaternion q, float MinimumX, float MaximumX)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX + Quaternion.kEpsilon, MaximumX - Quaternion.kEpsilon);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}