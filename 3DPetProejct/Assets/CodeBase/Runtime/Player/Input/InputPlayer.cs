using UnityEngine;

namespace CodeBase.Runtime.Player.Input
{
  public class InputPlayer
  {
    private PlayerActions _playerActions;
    private Transform _camera;

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