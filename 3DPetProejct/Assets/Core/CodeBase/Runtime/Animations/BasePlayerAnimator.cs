﻿using UnityEngine;

namespace Core.CodeBase.Runtime.Animations
{
  public abstract class BasePlayerAnimator : MonoBehaviour
  {
    public abstract void UpdateMovement(Vector3 velocity);
  }
}