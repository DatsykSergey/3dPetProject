using System;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM.Transitions
{
  public class CheckMovementInput : ITransition
  {
    private readonly IPlayerInput _input;
    private readonly bool _result;
    public Type NextStateType { get; }

    public CheckMovementInput(IPlayerInput input, bool result, Type nextType)
    {
      _input = input;
      _result = result;
      NextStateType = nextType;
    }
    
    public bool IsValid()
    {
      return (_input.GetMoveDirection() != Vector2.zero) == _result;
    }
  }
}