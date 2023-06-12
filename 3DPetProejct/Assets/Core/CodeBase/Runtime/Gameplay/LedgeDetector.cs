using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class LedgeDetector : MonoBehaviour
  {
    [SerializeField] private OverlapBox _overlapBox = new OverlapBox();
    private Vector3 _nearPointToCollider;

    public BoxCollider NearBoxCollider { get; private set; } = null;

    public bool HasLedge => NearBoxCollider != null;


    private void FixedUpdate()
    {
      if (Time.frameCount % 3 != 0)
      {
        return;
      }

      _overlapBox.UpdateOverlapBox(transform);
    }

    private void Update()
    {
      TryFindNearestPoint();
    }

    private void TryFindNearestPoint()
    {
      NearBoxCollider = null;
      float minDistance = float.MaxValue;
      for (int i = 0; i < _overlapBox.Count; i++)
      {
        BoxCollider boxCollider = _overlapBox.Result[i] as BoxCollider;
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
          NearBoxCollider = boxCollider;
        }
      }

      if (NearBoxCollider != null)
      {
        Vector3 rightPoint = GetRightPoint(NearBoxCollider);
        Vector3 leftPoint = GetLeftPoint(NearBoxCollider);

        CustomGizmos.Instance.DrawLine(transform.position, _nearPointToCollider, Color.blue);
        CustomGizmos.Instance.DrawLine(rightPoint, leftPoint, Color.green);
        CustomGizmos.Instance.DrawSphere(NearBoxCollider.transform.position, 0.5f, Color.green);
      }
    }

    private bool TryGetNearPointToCollider(BoxCollider boxCollider, out Vector3 point)
    {
      Vector3 distanceToBoxCollider = transform.position - boxCollider.transform.position;

      float distanceFromCenterBoxToNearPoint = Vector3.Dot(boxCollider.transform.right, distanceToBoxCollider);
      if (Mathf.Abs(distanceFromCenterBoxToNearPoint) >= boxCollider.size.x * 0.5f)
      {
        point = default;
        return false;
      }
      
      point = boxCollider.transform.position + boxCollider.transform.right * distanceFromCenterBoxToNearPoint;
      return true;
    }

    // to math extension
    private static Vector3 GetRightPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position + boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    // to math extension
    private static Vector3 GetLeftPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position - boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    private void OnDrawGizmos()
    {
      _overlapBox.DrawGizmos(transform);
    }
  }
}