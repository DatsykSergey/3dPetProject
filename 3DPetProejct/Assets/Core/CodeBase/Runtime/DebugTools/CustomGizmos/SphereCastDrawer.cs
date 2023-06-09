using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class SphereCastDrawer : GizmosDrawer
  {
    private readonly Vector3 _position;
    private readonly Vector3 _direction;
    private readonly float _radius;
    private readonly float _distance;
    private readonly Color _color;

    public SphereCastDrawer(Vector3 position, Vector3 direction, float radius, float distance, Color color)
    {
      _position = position;
      _direction = direction;
      _radius = radius;
      _distance = distance;
      _color = color;
    }

    public override void Draw()
    {
      Gizmos.color = _color;
      Vector3 endPosition = _position + _direction * _distance;
      Gizmos.DrawWireSphere(_position, _radius);
      Gizmos.DrawLine(_position, endPosition);
      Gizmos.DrawWireSphere(endPosition, _radius);
    }
  }
}