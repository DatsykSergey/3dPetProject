using System;
using UnityEngine;

namespace Core.CodeBase.Runtime.Animations.Simple
{
  [AddComponentMenu("My animation/Test edge animator")]
  public class PlayerAnimator : BasePlayerAnimator
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _camera;

    private readonly int VerticalHash = Animator.StringToHash("Vertical");
    private readonly int GroundedHash = Animator.StringToHash("Grounded");
    private readonly int JumpHash = Animator.StringToHash("Jump");

    public override void UpdateMovement(Vector3 velocity, bool isGrounded)
    {
      Vector3 moveDirection = velocity.normalized;
      Vector3 cameraForward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;

      float vertical = Vector3.Dot(moveDirection, cameraForward);
      _animator.SetFloat(VerticalHash, vertical);
      _animator.SetBool(GroundedHash, isGrounded);
    }

    public override void Jump()
    {
      _animator.SetTrigger(JumpHash);
    }

    public override void JumpReset()
    {
      _animator.ResetTrigger(JumpHash);
    }

    public override void Grab()
    {
      
    }

    public override void UnGrab()
    {
    }

    public override void StartGrabToCrouch()
    {
    }
  }
}