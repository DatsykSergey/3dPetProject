using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class EdgeFinder : MonoBehaviour
  {
    [SerializeField] private BaseObstacleChecker _forward;
    [SerializeField] private BaseObstacleChecker _up;
    
    public bool IsHasPoint { get; private set; }
    public Vector3 EdgePoint { get; private set; }
    public Vector3 Normal { get; private set; }

    private void Update()
    {
      if (_up.HasObstacle == false || _forward.HasObstacle == false)
      {
        IsHasPoint = false;
        return;
      }

      EdgePoint = GetEdgePoint();
      Normal = GetEdgeNormal();
      IsHasPoint = true;
      CustomGizmos.Instance.DrawSphere(EdgePoint, 0.2f, Color.green);
    }

    private Vector3 GetEdgePoint()
    {
      return new Vector3(_forward.HitPoint.x, _up.HitPoint.y, _forward.HitPoint.z);
    }

    private Vector3 GetEdgeNormal()
    {
      Vector3 normal = _forward.HitNormal;
      normal.y = 0;
      return normal.normalized;
    }
  }
}