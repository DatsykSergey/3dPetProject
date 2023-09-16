using System;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class NearLedgeFinder : MonoBehaviour
  {
    [SerializeField] private OverlapBox _overlapBox;
    [SerializeField] private float _minDistance = 0.5f;
    private IPlayerInput _playerInput;

    private Vector3 RootPosition => transform.position;

    [Inject]
    private void Construct(IPlayerInput playerInput)
    {
      _playerInput = playerInput;
    }

    private void Awake()
    {
      _overlapBox.SetResultSize(24);
    }

    private void FixedUpdate()
    {
      _overlapBox.CheckOverlap(transform);
    }

    private void Update()
    {
      Vector3 moveDirection = transform.up * _playerInput.GetMoveDirection().y +
                              transform.right * _playerInput.GetMoveDirection().x;
      
      CustomGizmos.Instance.DrawLine(transform.position, transform.position + moveDirection, Color.green, false);

      if (moveDirection == Vector3.zero)
      {
        return;
      }

      float maxDot = float.MinValue;
      int resultIndex = -1;
      float sqrMinDistance = _minDistance * _minDistance;
      for (int i = 0; i < _overlapBox.Count; i++)
      {
        Vector3 colliderPosition = _overlapBox.Result[i].transform.position;
        Vector3 toCollider = (colliderPosition - RootPosition);
        float sqrDistance = toCollider.sqrMagnitude;
        if (sqrDistance < sqrMinDistance)
        {
          continue;
        }
        
        float dot = (Vector3.Dot(toCollider.normalized, moveDirection) - 0.85f) / sqrDistance;
        CustomGizmos.Instance.DrawText(colliderPosition, $"{dot.ToString("F4")}", Color.green);
        if (dot > 0 && maxDot < dot)
        {
          maxDot = dot;
          resultIndex = i;
        }
      }

      if (resultIndex != -1)
      {
        CustomGizmos.Instance.DrawSphere(_overlapBox.Result[resultIndex].transform.position, 0.26f, Color.blue);
      }
    }


    private void OnDrawGizmos()
    {
      _overlapBox.DrawGizmos(transform);
    }
  }
}