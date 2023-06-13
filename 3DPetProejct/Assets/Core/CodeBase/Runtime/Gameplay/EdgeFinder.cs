using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class EdgeFinder : MonoBehaviour
  {
    [SerializeField] private BaseObstacleChecker _forward;
    [SerializeField] private BaseObstacleChecker _up;

    private void Update()
    {
      if (_up.HasObstacle == false || _forward.HasObstacle == false)
      {
        return;
      }

      Vector3 edgePoint = _forward.HitPoint;
      edgePoint.y = _up.HitPoint.y;
      CustomGizmos.Instance.DrawSphere(edgePoint, 0.2f, Color.green);
    }
  }
}