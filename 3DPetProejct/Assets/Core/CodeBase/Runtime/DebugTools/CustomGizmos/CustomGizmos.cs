using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class CustomGizmos : MonoBehaviour
  {
    private static CustomGizmos _instance;

    public static CustomGizmos Isntance
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

    public void DrawLine(Vector3 rightPoint, Vector3 leftPoint, Color green)
    {
      _drawers.Push(new LineDrawer(leftPoint, rightPoint, green));
    }

    public void DrawSphere(Vector3 position, float radius, Color color)
    {
      _drawers.Push(new MeshDrawer(position, radius, color, _sphereMesh));
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