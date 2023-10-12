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
    
    public void JumpUp()
    {
      _movement.JumpUp();  
      _animator?.JumpReset();
    }

    public void OnEndGrabUp()
    {
      _edgeGrab.EndGrabUp();
    }
  }
}