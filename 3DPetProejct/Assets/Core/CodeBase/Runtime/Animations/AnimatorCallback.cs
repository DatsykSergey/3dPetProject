using System;
using Core.CodeBase.Runtime.Gameplay;
using Core.CodeBase.Runtime.Gameplay.Player;
using UnityEngine;

namespace Core.CodeBase.Runtime.Animations
{
  public class AnimatorCallback : MonoBehaviour
  {
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private BasePlayerAnimator _animator;
    [SerializeField] private EdgeGrab _edgeGrab;

    private void OnEnable()
    {
    }

    public void JumpUp()
    {
      if (enabled == false)
      {
        return;
      }
      _movement.MakeJump();  
      _animator?.JumpReset();
    }

    public void OnEndGrabUp()
    {
      if (enabled == false)
      {
        return;
      }
      
      _edgeGrab.EndGrabUp();
    }
  }
}