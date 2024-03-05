using System;
using Core.CodeBase.Runtime.CharacterFSM.Transitions;

namespace Core.CodeBase.Runtime.CharacterFSM.States
{
  public class State
  {
    private ITransition[] _transitions;

    public void SetTransitions(ITransition[] transitions)
    {
      _transitions = transitions;
    }

    public bool TryGetNextState(out Type state)
    {
      foreach (ITransition transition in _transitions)
      {
        if (transition.IsValid())
        {
          state = transition.NextStateType;
          return true;
        }
      }

      state = null;
      return false;
    }
    
    public virtual void Entry()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Exit()
    {
    }
  }
}