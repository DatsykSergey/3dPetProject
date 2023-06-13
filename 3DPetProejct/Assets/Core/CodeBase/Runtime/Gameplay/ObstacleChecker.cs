using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class ObstacleChecker : MonoBehaviour
  {
    [SerializeField] private float _castRadius;
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _layerMask;

    private RaycastHit _hits;
    [field:SerializeField] public bool HasObstacle { get; private set; }
    public Vector3 HitPoint => _hits.point;
    public Vector3 HitNormal => _hits.normal;

    private void FixedUpdate()
    {
      Ray ray = new Ray(transform.position, transform.forward);
      HasObstacle = Physics.SphereCast(ray, _castRadius, out _hits, _castDistance, _layerMask);
      // HasObstacle = Physics.Raycast(transform.position,transform.forward, out _hits, _castDistance, _layerMask);
    }

    private void Update()
    {
      Color color = HasObstacle ? Color.red : Color.blue;
      CustomGizmos.Instance.DrawSphereCast(transform.position, transform.forward, _castRadius, HasObstacle ? _hits.distance : _castDistance, color);
    }
  }
}