using Core.CodeBase.Runtime.CharacterFSM.States;
using Core.CodeBase.Runtime.CharacterFSM.Transitions;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  public class StateMachineMono : MonoBehaviour
  {
    [SerializeField] private CharacterData _data;
    [SerializeField] private CharacterComponents _components;
    [SerializeField] private StateMachine _stateMachine;

    [Inject] private IPlayerInput _input;


    private void Awake()
    {
      State[] states = new StateMachineBuilder()
        .AddState(new IdleState(_components.Animator), new ITransition[]
        {
          new CheckIsGroundedTransition(_components.GroundChecker, false, typeof(FallingState)),
          new CheckJumpTransition(_input, typeof(JumpState)),
          new CheckMovementInput(_input, true, typeof(MovementState)),
        })
        .AddState(new FallingState(_components.Animator, _input), new ITransition[]
        {
          new CheckIsGroundedTransition(_components.GroundChecker, true, typeof(IdleState)),
        })
        .AddState(new JumpState(), new ITransition[]
        {
          new CheckIsGroundedTransition(_components.GroundChecker, false, typeof(IdleState)),
        })
        .AddState(new MovementState(_data.Movement, _components.Animator, _components.CharacterController), 
          new ITransition[]
        {
          new CheckIsGroundedTransition(_components.GroundChecker, false, typeof(FallingState)),
          new CheckJumpTransition(_input, typeof(JumpState)),
          new CheckMovementInput(_input, false, typeof(IdleState)),
        })
        .Build();
      
      _stateMachine = new StateMachine(states);
      _stateMachine.Start<IdleState>();
    }

    private void Update()
    {
      _stateMachine.Update();
    }

    private void FixedUpdate()
    {
      _stateMachine.FixedUpdate();
    }
  }
}