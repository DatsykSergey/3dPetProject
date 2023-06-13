using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class CustomGizmos : MonoBehaviour
  {
    private static CustomGizmos _instance;

    public static CustomGizmos Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new GameObject("CUSTOM_GIZMOS")
            .AddComponent<CustomGizmos>();
        }

        return _instance;
      }
    }

    private readonly Stack<GizmosDrawer> _drawers = new(capacity: 100);
    private Mesh _sphereMesh;

    private void Awake()
    {
      var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      _sphereMesh = sphere.GetComponent<MeshFilter>().mesh;
      Destroy(sphere);
    }

    public void DrawLine(Vector3 rightPoint, Vector3 leftPoint, Color green, bool markBeginEnd = true)
    {
      _drawers.Push(new LineDrawer(leftPoint, rightPoint, green, markBeginEnd));
    }

    public void DrawSphere(Vector3 position, float radius, Color color)
    {
      _drawers.Push(new MeshDrawer(position, radius, color, _sphereMesh));
    }

    public void DrawSphereCast(Vector3 position, Vector3 direction, float radius, float distance, Color color)
    {
      _drawers.Push(new SphereCastDrawer(position, direction, radius, distance, color));
    }

    public void DrawText(Vector3 position, string text, Color color)
    {
      Instance._drawers.Push(new DrawText(position, text, color));
    }

    private void OnDrawGizmos()
    {
      while (_drawers.IsEmpty() == false)
      {
        _drawers.Pop().Draw();
      }
    }
  }
}