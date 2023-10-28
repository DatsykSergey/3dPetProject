using System;

namespace Core.CodeBase.Runtime.CharacterFSM.Transitions
{
  public interface ITransition
  {
    Type NextStateType { get; }
    bool IsValid();
  }
}