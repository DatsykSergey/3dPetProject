using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEditor;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class ObstacleCheckerBySphere : BaseObstacleChecker
  {
    [SerializeField] private float _castRadius = 0.25f;

    private void FixedUpdate()
    {
      Ray ray = new Ray(transform.position, transform.forward);
      HasObstacle = Physics.SphereCast(ray, _castRadius, out _hits, _castDistance, _layerMask);
    }

    private void Update()
    {
      Color color = HasObstacle ? Color.red : Color.blue;
      CustomGizmos.Instance.DrawSphereCast(transform.position, transform.forward, _castRadius, HasObstacle ? _hits.distance : _castDistance, color);
    }

    private void OnDrawGizmos()
    {
      if (EditorApplication.isPlaying == true)
      {
        return;
      }
      
      Gizmos.color = Color.blue;
      Gizmos.DrawSphere(transform.position, _castRadius);
      Gizmos.DrawLine(transform.position, transform.position + transform.forward * _castDistance);
    }
  }
}