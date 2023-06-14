using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class CubeCastDrawer : GizmosDrawer
  {
    private readonly Vector3 _position;
    private readonly Quaternion _rotation;
    private readonly Vector3 _forward;
    private readonly Vector3 _boxSize;
    private readonly float _hitsDistance;
    private readonly Color _color;

    public CubeCastDrawer(Vector3 position, Quaternion rotation, Vector3 forward, Vector3 boxSize, float hitsDistance, Color color)
    {
      _position = position;
      _rotation = rotation;
      _forward = forward;
      _boxSize = boxSize;
      _hitsDistance = hitsDistance;
      _color = color;
    }

    public override void Draw()
    {
      Gizmos.color = _color;
      Gizmos.DrawLine(_position, _position + _forward * _hitsDistance);
      Matrix4x4 matrix = Gizmos.matrix;
      Debug.Log(matrix.ToString());
      Gizmos.matrix = Matrix4x4.TRS(_position, _rotation, Vector3.one);
      Gizmos.DrawWireCube(Vector3.zero, _boxSize);
      Gizmos.DrawWireCube(Vector3.forward * _hitsDistance, _boxSize);
      Gizmos.matrix = matrix;
    }
  }
}