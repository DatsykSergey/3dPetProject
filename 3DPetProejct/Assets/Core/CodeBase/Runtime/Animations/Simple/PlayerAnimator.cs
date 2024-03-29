﻿using UnityEngine;

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
    private readonly int GrabHash = Animator.StringToHash("Grab");
    private readonly int GrabUpHash = Animator.StringToHash("GrabUp");

    public override void UpdateMovement(Vector3 velocity, bool isGrounded)
    {
      _animator.SetFloat(VerticalHash, Mathf.Clamp01(velocity.magnitude));
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
      _animator.SetBool(GrabHash, true);
      _animator.ResetTrigger(GrabUpHash);
    }

    public override void UnGrab()
    {
      _animator.SetBool(GrabHash, false);
      _animator.ResetTrigger(GrabUpHash);
    }

    public override void StartGrabToCrouch()
    {
      _animator.SetBool(GrabHash, false);
      _animator.SetTrigger(GrabUpHash);
    }
  }
}