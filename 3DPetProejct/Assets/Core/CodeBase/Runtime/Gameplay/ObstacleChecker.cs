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
    private bool HasObstacle => _hits.Length > 0;

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