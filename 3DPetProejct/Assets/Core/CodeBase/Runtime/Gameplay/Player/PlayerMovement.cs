using Core.CodeBase.Runtime.Animations;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Gameplay.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private BasePlayerAnimator _animator;
    
    private IPlayerInput _input;
    [SerializeField] private Vector3 _fallVelocity;
    private const float GravityY = -9.81f;
    [field: SerializeField] public bool IsGrounded { get; private set; } = true;
    private const float JumpHeight = 1.2f;

    private float _currentRotateVelocity;

    [Inject]
    private void Construct(IPlayerInput input)
    {
      _input = input;
    }


    private void Update()
    {
      IsGrounded = _characterController.isGrounded;
      
      if (IsGrounded && _fallVelocity.y < 0)
      {
        _fallVelocity.y = 0;
      }

      Vector3 moveDirection = _input.GetCameraRelativeMoveDirection();
      Vector3 velocity = moveDirection * (_speed * Time.deltaTime);
      _characterController.Move(velocity);
      
      if (_input.IsPressJump() && IsGrounded)
      {
        _animator?.Jump();
        // JumpUp();
      }

      _fallVelocity.y += GravityY * Time.deltaTime;
      _characterController.Move(_fallVelocity * Time.deltaTime);

      float forwardVelocity = Vector3.Dot(moveDirection, transform.forward);
      float rightVelocity = Vector3.Dot(moveDirection, transform.right);
      _animator?.UpdateMovement(moveDirection, _fallVelocity.y > -0.5 && _fallVelocity.y < 0.5);

      if (moveDirection == Vector3.zero)
        return;
      
      float angel = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
      float newAngel = Mathf.SmoothDampAngle(transform.eulerAngles.y, angel, ref _currentRotateVelocity, _rotationSpeed);
      
      transform.rotation = Quaternion.Euler(0f, newAngel, 0f);
    }

    public void FreezeMovement()
    {
      enabled = false;
    }

    public void UnfreezeMovement()
    {
      _fallVelocity.y = 0f;
      enabled = true;
    }

    public void MakeJump()
    {
      _fallVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityY);
    }
  }
}