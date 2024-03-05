using System;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  public class GroundChecker : MonoBehaviour
  {
    [SerializeField] private float _radios;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private LayerMask _layerMask;

    [field: SerializeField] public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
      IsGrounded = Physics.CheckSphere(transform.position + _offset, _radios, _layerMask);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.yellow;
      Gizmos.DrawSphere(transform.position + _offset, _radios);
    }
#endif
  }
}