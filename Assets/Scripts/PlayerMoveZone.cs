using System;
using UnityEngine;

public class PlayerMoveZone : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform middlePoint;
    public Transform groundPoint;

    [SerializeField] private int gizmosPointsCount = 20;

    public Vector3 GetMovePoint(float t)
    {
        return GetBezierPosition(t);
    }

    private Vector3 GetBezierPosition(float t)
    {
        var pos = new Vector3(
            GetBezierFloat(leftPoint.position.x, middlePoint.position.x, rightPoint.position.x, t),
            GetBezierFloat(leftPoint.position.y, middlePoint.position.y, rightPoint.position.y, t),
            GetBezierFloat(leftPoint.position.z, middlePoint.position.z, rightPoint.position.z, t)
        );
        return pos;
    }

    private float GetBezierFloat(float point1, float point2, float point3, float t)
    {
        return (1 - t) * (1 - t) * point1 + 2 * (1 - t) * t * point2 +
               t * t * point3; // (1−t)^2*x1 + 2(1−t)tx2 + t^2*x3
    }


    private void OnDrawGizmos()
    {
        if (!leftPoint || !middlePoint || !rightPoint) return;

        var prevPoint = GetBezierPosition(0);
        for (int i = 0; i < gizmosPointsCount; i++)
        {
            var bezierPosition = GetBezierPosition(i / (float) gizmosPointsCount);
            Gizmos.DrawLine(prevPoint, bezierPosition);
            prevPoint = bezierPosition;
        }
    }
}