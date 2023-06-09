using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class SphereDrawer : GizmosDrawer
  {
    private readonly Vector3 _position;
    private readonly float _radius;
    private readonly Color _color;

    public SphereDrawer(Vector3 position, float radius, Color color)
    {
      _color = color;
      _radius = radius;
      _position = position;
    }

    public override void Draw()
    {
      Gizmos.color = _color;
      Gizmos.DrawWireSphere(_position, _radius);
    }
  }
}