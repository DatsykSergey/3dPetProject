using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class LineDrawer : GizmosDrawer
  {
    private readonly Vector3 _firstPoint;
    private readonly Vector3 _secondPoint;
    private readonly Color _color;

    public LineDrawer(Vector3 firstPoint, Vector3 secondPoint, Color color)
    {
      _firstPoint = firstPoint;
      _secondPoint = secondPoint;
      _color = color;
    }

    public override void Draw()
    {
      Gizmos.color = _color;
      Gizmos.DrawLine(_firstPoint, _secondPoint);
      Vector3 line1 = _secondPoint - _firstPoint;
      Vector3 line2 = new Vector3(line1.z, line1.y, -line1.x).normalized;
      Vector3 line3 = Vector3.Cross(line2, line1).normalized;
      Gizmos.DrawLine(_firstPoint + line2 * 0.1f, _firstPoint - line2 * 0.1f);
      Gizmos.DrawLine(_firstPoint + line3 * 0.1f, _firstPoint - line3 * 0.1f);
      Gizmos.DrawLine(_firstPoint + line2 * 0.1f + line1, _firstPoint - line2 * 0.1f + line1);
      Gizmos.DrawLine(_firstPoint + line3 * 0.1f + line1, _firstPoint - line3 * 0.1f + line1);
    }
  }
}