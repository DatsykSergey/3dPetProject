using Core.CodeBase.Runtime.Animations;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM.States
{
  public class MovementState : State
  {
    private MovementData _dataMovement;
    private BasePlayerAnimator _animator;
    private CharacterController _characterController;

    public MovementState(MovementData dataMovement,
      BasePlayerAnimator animator,
      CharacterController characterController)
    {
      _characterController = characterController;
      _animator = animator;
      _dataMovement = dataMovement;
    }

    public override void FixedUpdate()
    {
      
    }
  }
}