using UnityEngine;
using UnityEngine.Profiling;

namespace CodeBase.Runtime.Gameplay.Player
{
  public class EdgeFinder : MonoBehaviour
  {
    private readonly RaycastHit[] _raycastHits = new RaycastHit[1];
    
    private const float MAXDistance = 0.5f;
    private const float UpShift = 1f;

    private Vector3? _forwardHitPoint = null;
    private Vector3? _upHitPoint = null;

    public void Update()
    {
      Profiler.BeginSample("Raycast profiling");
      Vector3 horizontalForward = GetHorizontalForward();
      Ray rayForward = new Ray(transform.position, horizontalForward);
      if (Physics.RaycastNonAlloc(rayForward, _raycastHits, MAXDistance) == 0)
      {
        _forwardHitPoint = null;
        _upHitPoint = null;
        Profiler.EndSample();
        return;
      }

      _forwardHitPoint = _raycastHits[0].point;

      Vector3 rayOrigin =_raycastHits[0].point + horizontalForward * 0.05f;
      rayOrigin.y += UpShift;
      
      Ray rayUp = new Ray(rayOrigin, Vector3.down);
      if (Physics.RaycastNonAlloc(rayUp, _raycastHits, UpShift) == 0)
      {
        _upHitPoint = null;
        Profiler.EndSample();
        return;
      }

      _upHitPoint = _raycastHits[0].point;
      Profiler.EndSample();
    }
    
    private Vector3 GetHorizontalForward()
    {
      Vector3 forward = transform.forward;
      forward.y = 0;
      forward.Normalize();
      return forward;
    }

    private void OnDrawGizmos()
    {
      if (_forwardHitPoint != null)
      {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_forwardHitPoint.Value, 0.1f);
        Gizmos.DrawLine(transform.position, _forwardHitPoint.Value);
      }
      else
      {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + GetHorizontalForward() * MAXDistance);
      }
      
      if (_upHitPoint != null)
      {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_upHitPoint.Value, 0.1f);
      }
    }
  }
}