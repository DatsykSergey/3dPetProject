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
    
    
  }
}