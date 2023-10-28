using Core.CodeBase.Runtime.Animations;
using Core.CodeBase.Runtime.CharacterFSM.States;
using Core.CodeBase.Runtime.CharacterFSM.Transitions;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  public class StateMachineMono : MonoBehaviour
  {
    [SerializeField] private BasePlayerAnimator _animator;
    [SerializeField] private GroundChecker _groundChecker;
    
    [Inject] private IPlayerInput _input;
    
    private StateMachine _stateMachine;

    private void Awake()
    {

      State[] states = new StateMachineBuilder()
        .AddState(new IdleState(_animator), new ITransition[]
        {
          new CheckIsGroundedTransition(_groundChecker, false, typeof(FallingState)),
          new CheckJumpTransition(_input, typeof(JumpState)),
          new CheckMovementInput(_input, true, typeof(MovementState)),
        })
        .AddState(new FallingState(_animator, _input), new ITransition[]
        {
          new CheckIsGroundedTransition(_groundChecker, true, typeof(IdleState)),
        })
        .AddState(new JumpState(), new ITransition[]
        {
          new CheckIsGroundedTransition(_groundChecker, false, typeof(IdleState)),
        })
        .AddState(new MovementState(), new ITransition[]
        {
          new CheckIsGroundedTransition(_groundChecker, false, typeof(FallingState)),
          new CheckJumpTransition(_input, typeof(JumpState)),
          new CheckMovementInput(_input, false, typeof(IdleState)),
        })
        .Build();
      
      _stateMachine = new StateMachine(states);
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