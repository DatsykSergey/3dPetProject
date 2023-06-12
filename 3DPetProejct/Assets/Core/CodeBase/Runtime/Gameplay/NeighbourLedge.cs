using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class NeighbourLedge : MonoBehaviour
  {
    [SerializeField] private OverlapBox _overlapBox;

    private void FixedUpdate()
    {
      _overlapBox.CheckOverlap(transform);
    }

    private void Update()
    {
      for (var index = 0; index < _overlapBox.Count; index++)
      {
        Collider collider = _overlapBox.Result[index];
        CustomGizmos.Instance.DrawSphere(collider.transform.position, 0.5f, Color.blue);
      }

      if (TryFindNearPoint(out Vector3 point))
      {
        CustomGizmos.Instance.DrawSphere(point, 0.25f, Color.red);
      }
    }

    public bool TryFindNearPoint(out Vector3 point)
    {
      if (_overlapBox.Count == 0)
      {
        point = default;
        return false;
      }

      BoxCollider result = null;
      float minDistance = float.MaxValue;
      Vector3 resultPoint = default;
      for (int i = 0; i < _overlapBox.Count; i++)
      {
        BoxCollider boxCollider = _overlapBox.Result[i] as BoxCollider;
        Vector3 leftPoint = MathExtension.GetLeftPoint(boxCollider);
        Vector3 rightPoint = MathExtension.GetRightPoint(boxCollider);

        float sqrDistance = (transform.position - leftPoint).sqrMagnitude;
        if (sqrDistance < minDistance)
        {
          result = boxCollider;
          minDistance = sqrDistance;
          resultPoint = leftPoint;
        }

        sqrDistance = (transform.position - rightPoint).sqrMagnitude;
        if (sqrDistance < minDistance)
        {
          result = boxCollider;
          minDistance = sqrDistance;
          resultPoint = rightPoint;
        }
      }

      if (result == null)
      {
        point = default;
        return false;
      }

      point = resultPoint;
      return true;
    }

    private void OnDrawGizmos()
    {
      _overlapBox.DrawGizmos(transform);
    }
  }
}