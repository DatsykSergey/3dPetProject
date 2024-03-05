using Core.CodeBase.Runtime.Animations;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM.States
{
  public class FallingState : State
  {
    private readonly BasePlayerAnimator _animator;
    private readonly IPlayerInput _input;

    public FallingState(BasePlayerAnimator animator, IPlayerInput input)
    {
      _animator = animator;
      _input = input;
    }

    public override void Entry()
    {
      _animator.UpdateMovement(Vector3.zero, false);
    }
  }
}