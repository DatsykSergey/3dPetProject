using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class LedgeDetector : MonoBehaviour
  {
    [SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField] private Vector3 _boxOffset = Vector3.zero;
    [SerializeField] private LayerMask _layerMask;
    private readonly Collider[] _result = new Collider[8];
    private int _count = 0;
    private Vector3 _nearPointToCollider;
    private BoxCollider _nearBoxCollider = null;

    private void FixedUpdate()
    {
      if (Time.frameCount % 3 != 0)
      {
        return;
      }

      _count = Physics.OverlapBoxNonAlloc(transform.TransformPoint(_boxOffset), _boxSize, _result, transform.rotation, _layerMask,
        QueryTriggerInteraction.UseGlobal);
    }

    private void Update()
    {
      TryFindNearestPoint();
    }

    private void TryFindNearestPoint()
    {
      int result = -1;
      _nearBoxCollider = null;
      float minDistance = float.MaxValue;
      for (int i = 0; i < _count; i++)
      {
        BoxCollider boxCollider = _result[i] as BoxCollider;
        if (boxCollider == null)
        {
          Debug.LogWarning("Find not box collider Ledge");
          continue;
        }

        if (TryGetNearPointToCollider(boxCollider, out Vector3 nearPointToCollider) == false)
        {
          continue;
        }

        float distanceToNearPoint = (nearPointToCollider - transform.position).sqrMagnitude;
        if (distanceToNearPoint < minDistance)
        {
          _nearPointToCollider = nearPointToCollider;
          _nearBoxCollider = boxCollider;
        }
      }

      if (_nearBoxCollider != null)
      {
        Vector3 rightPoint = GetRightPoint(_nearBoxCollider);
        Vector3 leftPoint = GetLeftPoint(_nearBoxCollider);

        CustomGizmos.Instance.DrawLine(transform.position, _nearPointToCollider, Color.blue);
        CustomGizmos.Instance.DrawLine(rightPoint, leftPoint, Color.green);
        CustomGizmos.Instance.DrawSphere(_nearBoxCollider.transform.position, 0.5f, Color.green);
      }
    }

    private bool TryGetNearPointToCollider(BoxCollider boxCollider, out Vector3 point)
    {
      Vector3 distanceToBoxCollider = transform.position - boxCollider.transform.position;

      float distanceFromCenterBoxToNearPoint = Vector3.Dot(boxCollider.transform.right, distanceToBoxCollider);
      if (distanceFromCenterBoxToNearPoint >= boxCollider.size.x * 0.5f)
      {
        point = default;
        return false;
      }
      
      point = boxCollider.transform.position + boxCollider.transform.right * distanceFromCenterBoxToNearPoint;
      return true;
    }

    private static Vector3 GetRightPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position + boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    private static Vector3 GetLeftPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position - boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.blue;
      Gizmos.matrix = Matrix4x4.TRS(transform.TransformPoint(_boxOffset), transform.rotation, Vector3.one);
      Gizmos.DrawWireCube(Vector3.zero, _boxSize * 2);
    }
  }
}