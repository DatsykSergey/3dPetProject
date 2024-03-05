using System;
using System.Collections.Generic;
using System.Linq;
using Core.CodeBase.Runtime.CharacterFSM.States;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  public class StateMachine
  {
    private readonly Dictionary<Type, State> _states;
    private State _current;

    public StateMachine(State[] states)
    {
      _states = states.ToDictionary(state => state.GetType());
    }

    public void Start<TState>() where TState : State
    {
      NextState(typeof(TState));
    }

    public void Update()
    {
      if (_current.TryGetNextState(out Type nextStateType))
      {
        NextState(nextStateType);
      }
      _current.Update();
    }

    public void FixedUpdate()
    {
      _current.FixedUpdate();
    }

    private void NextState(Type stateType)
    {
      _current?.Exit();
      _current = _states[stateType];
      _current.Entry();
    }
  }
}