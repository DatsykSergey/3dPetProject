using System.Collections.Generic;
using Core.CodeBase.Runtime.CharacterFSM.States;
using Core.CodeBase.Runtime.CharacterFSM.Transitions;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  public class StateMachineBuilder
  {
    private readonly List<State> _states = new();

    public StateMachineBuilder AddState(State state, ITransition[] transitions)
    {
      state.SetTransitions(transitions);
      _states.Add(state);
      return this;
    }

    public State[] Build()
    {
      State[] result =  _states.ToArray();
      _states.Clear();
      return result;
    }
  }
}