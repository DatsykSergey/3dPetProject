using Core.CodeBase.Runtime.Animations;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM.States
{
  public class MovementState : State
  {
    private readonly IPlayerInput _input;
    private readonly MovementData _dataMovement;
    private readonly BasePlayerAnimator _animator;
    private readonly CharacterController _characterController;
    private readonly GroundChecker _groundChecker;

    private Vector3 _fallVelocity;
    private float _currentRotateVelocity;

    public MovementState(IPlayerInput input,
      MovementData dataMovement,
      BasePlayerAnimator animator,
      CharacterController characterController,
      GroundChecker groundChecker)
    {
      _input = input;
      _characterController = characterController;
      _animator = animator;
      _dataMovement = dataMovement;
      _groundChecker = groundChecker;
    }

    public override void FixedUpdate()
    {
      Vector3 moveDirection = _input.GetCameraRelativeMoveDirection();
      Vector3 velocity = moveDirection * (_dataMovement.Speed * Time.deltaTime);
      _characterController.Move(velocity);
      
      if (_input.IsPressJump() && _groundChecker.IsGrounded)
      {
        _animator?.Jump();
      }
      
      _fallVelocity.y += Physics.gravity.y * Time.deltaTime;
      _characterController.Move(_fallVelocity * Time.deltaTime);

      _animator?.UpdateMovement(moveDirection, _groundChecker.IsGrounded);
      
      float angel = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
      float newAngel =
        Mathf.SmoothDampAngle(_characterController.transform.eulerAngles.y, angel, ref _currentRotateVelocity, _dataMovement.RotationSpeed);

      _characterController.transform.rotation = Quaternion.Euler(0f, newAngel, 0f);
    }
  }
}