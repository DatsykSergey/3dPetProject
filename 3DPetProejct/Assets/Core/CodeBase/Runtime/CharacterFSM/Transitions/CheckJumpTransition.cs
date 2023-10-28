using System;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;

namespace Core.CodeBase.Runtime.CharacterFSM.Transitions
{
  public class CheckJumpTransition : ITransition
  {
    private readonly IPlayerInput _input;
    public Type NextStateType { get; }

    public CheckJumpTransition(IPlayerInput input, Type nextState)
    {
      _input = input;
      NextStateType = nextState;
    }

    public bool IsValid()
    {
      return _input.IsPressJump();
    }
  }
}