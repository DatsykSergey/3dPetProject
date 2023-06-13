using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEditor;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class ObstacleCheckerByBox : BaseObstacleChecker
  {
    [SerializeField] private Vector3 _halfBoxSize = Vector3.one;
    
    private void FixedUpdate()
    {
      HasObstacle = Physics.BoxCast(transform.position, _halfBoxSize, transform.forward, out _hits, transform.rotation, _castDistance, _layerMask);
    }

    private void Update()
    {
      Color color = HasObstacle ? Color.red : Color.blue;
      CustomGizmos.Instance.DrawBoxCast(transform.position, transform.rotation, transform.forward, _halfBoxSize*2, HasObstacle ? _hits.distance : _castDistance, color);
    }

    private void OnDrawGizmos()
    {
      if (EditorApplication.isPlaying == true)
      {
        return;
      }
      
      Gizmos.color = Color.blue;
      Gizmos.DrawLine(transform.position, transform.position + transform.forward * _castDistance);
      Gizmos.matrix = transform.localToWorldMatrix;
      Gizmos.DrawCube(Vector3.zero, _halfBoxSize * 2f);
    }
  }
}