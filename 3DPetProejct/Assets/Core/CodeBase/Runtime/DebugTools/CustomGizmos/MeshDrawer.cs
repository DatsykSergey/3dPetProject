using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class MeshDrawer : GizmosDrawer
  {
    private readonly Vector3 _position;
    private readonly Quaternion _rotation;
    private readonly Vector3 _scale;
    private readonly Color _color;
    private readonly Mesh _mesh;

    public MeshDrawer(Vector3 position, float scale, Color color, Mesh mesh)
    {
      _position = position;
      _rotation = Quaternion.identity;
      _scale = new Vector3(scale, scale, scale);
      _color = color;
      _mesh = mesh;
    }

    public override void Draw()
    {
      Gizmos.color = _color;
      Gizmos.DrawWireMesh(_mesh, _position, _rotation, _scale);
    }
  }
}