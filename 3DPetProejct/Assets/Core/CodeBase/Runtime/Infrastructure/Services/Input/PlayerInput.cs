using UnityEngine;

namespace CodeBase.Runtime.Infrastructure.Services.Input
{
  public class PlayerInput : IPlayerInput
  {
    private readonly PlayerActions _playerActions;
    
    private Transform _camera;

    public PlayerInput()
    {
      _playerActions = new PlayerActions();
      _playerActions.Enable();
    }

    public void SetPlayerCamera(Transform camera)
    {
      _camera = camera;
    }

    public Vector2 GetMoveDirection()
    {
      return _playerActions.Gameplay.MoveDirection.ReadValue<Vector2>();
    }

    public Vector3 GetCameraRelativeMoveDirection()
    {
      Vector3 forward = _camera.forward;
      forward.y = 0;
      forward.Normalize();

      Vector3 right = _camera.right;

      Vector2 localDirection = _playerActions.Gameplay.MoveDirection.ReadValue<Vector2>();
      return forward * localDirection.y + right * localDirection.x;
    }

    public Vector2 GetLookDelta()
    {
      return _playerActions.Gameplay.LookDelta.ReadValue<Vector2>();
    }

    public bool IsPressJump()
    {
      return _playerActions.Gameplay.Jump.IsPressed();
    }
  }
}