﻿using UnityEngine;

namespace Core.CodeBase.Runtime.Animations
{
  public abstract class BasePlayerAnimator : MonoBehaviour
  {
    public abstract void UpdateMovement(Vector3 velocity, bool isGrounded);
    public abstract void Jump();
    public abstract void JumpReset();
    public abstract void Grab();
    public abstract void UnGrab();
    public abstract void StartGrabToCrouch();
  }
}