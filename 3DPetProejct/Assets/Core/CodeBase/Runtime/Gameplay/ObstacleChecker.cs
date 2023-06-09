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
    
    private RaycastHit[] _hits = new RaycastHit[1];
    public bool HasObstacle => _hits.Length > 0;
    public Vector3 HitPoint => _hits[0].point;
    public Vector3 HitNormal => _hits[0].normal;

    private void FixedUpdate()
    {
      Ray ray = new Ray(transform.position, transform.forward);
      _hits = Physics.SphereCastAll(ray, _castRadius, _castDistance, _layerMask);
    }

    private void Update()
    {
      Color color = HasObstacle ? Color.red : Color.blue;
      CustomGizmos.Instance.DrawSphereCast(transform.position, transform.forward, _castRadius, _castDistance, color);
    }
  }
}