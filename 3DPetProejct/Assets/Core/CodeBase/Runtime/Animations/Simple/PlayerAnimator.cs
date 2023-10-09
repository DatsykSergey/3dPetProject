﻿using System;
using UnityEngine;

namespace Core.CodeBase.Runtime.Animations.Simple
{
  [AddComponentMenu("My animation/Test edge animator")]
  public class PlayerAnimator : BasePlayerAnimator
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _camera;
    
    private readonly int VerticalHash = Animator.StringToHash("Vertical");
      private readonly int FallVelocityHash = Animator.StringToHash("FallVelocity");

    private void OnEnable()
    {
    }

    public override void UpdateMovement(Vector3 velocity, float fallVelocity)
    {
      Vector3 moveDirection = velocity.normalized;
      Vector3 cameraForward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;

      float vertical = Vector3.Dot(moveDirection, cameraForward);
      _animator.SetFloat(VerticalHash, vertical);
      _animator.SetFloat(FallVelocityHash, fallVelocity);
    }

    private void Update()
    {
      
    }
  }
}