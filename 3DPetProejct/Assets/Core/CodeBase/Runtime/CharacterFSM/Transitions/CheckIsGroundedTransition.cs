using System;

namespace Core.CodeBase.Runtime.CharacterFSM.Transitions
{
  public class CheckIsGroundedTransition : ITransition
  {
    private readonly GroundChecker _groundChecker;
    private readonly bool _result;
    public Type NextStateType { get; }

    public CheckIsGroundedTransition(GroundChecker groundChecker, bool result, Type stateType)
    {
      _groundChecker = groundChecker;
      _result = result;
      NextStateType = stateType;
    }
    
    public bool IsValid()
    {
      return _groundChecker.IsGrounded == _result;
    }
  }
}