using CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;
    private IPlayerInput _input;
    private Vector3 _fallVelocity;
    private const float GravityY = -9.81f;
    private bool _isGrounded;
    private const float JumpHeight = 1.0f;
    
    [Inject]
    private void Construct(IPlayerInput input)
    {
      _input = input;
    }


    private void Update()
    {
      _isGrounded = _characterController.isGrounded;
      
      if (_isGrounded && _fallVelocity.y < 0)
      {
        _fallVelocity.y = 0;
      }
      
      Vector3 velocity = _input.GetCameraRelativeMoveDirection() * (_speed * Time.deltaTime);
      _characterController.Move(velocity);
      
      if (_input.IsPressJump() && _isGrounded)
      {
        _fallVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityY);
      }

      _fallVelocity.y += GravityY * Time.deltaTime;
      _characterController.Move(_fallVelocity * Time.deltaTime);
    }
  }
}