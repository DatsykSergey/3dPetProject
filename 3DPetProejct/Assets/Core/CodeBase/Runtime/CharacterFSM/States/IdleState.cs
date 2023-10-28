using Core.CodeBase.Runtime.Animations;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM.States
{
  public class IdleState : State
  {
    private readonly BasePlayerAnimator _animator;

    public IdleState(BasePlayerAnimator animator)
    {
      _animator = animator;
    }

    public override void Entry()
    {
      _animator.UpdateMovement(Vector3.zero, true);
    }
  }
}