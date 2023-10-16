using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.CodeBase.Runtime.Infrastructure.Services.Input
{
  public class PlayerInput : IPlayerInput
  {
    private readonly PlayerActions _playerActions;
    
    private Transform _camera;
    private bool _isRotateMouse = true;

    public PlayerInput()
    {
      _playerActions = new PlayerActions();
      _playerActions.Enable();
      _playerActions.Gameplay.StopGame.performed += OnStopButtonClick;
      _playerActions.Gameplay.StopMouseRotation.performed += SwitchMouseRotation;
    }

    private void SwitchMouseRotation(InputAction.CallbackContext obj)
    {
      if (obj.performed)
      {
        _isRotateMouse = !_isRotateMouse;
      }
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

      Vector2 localDirection = _isRotateMouse ? _playerActions.Gameplay.MoveDirection.ReadValue<Vector2>() : Vector2.zero;
      return forward * localDirection.y + right * localDirection.x;
    }

    public Vector2 GetLookDelta()
    {
      return _isRotateMouse ? _playerActions.Gameplay.LookDelta.ReadValue<Vector2>() : Vector2.zero;
    }

    public bool IsPressJump()
    {
      return _playerActions.Gameplay.Jump.WasPerformedThisFrame();
    }

    public bool IsPressJumpDown()
    {
      return _playerActions.Gameplay.JumpDown.IsPressed();
    }

    private void OnStopButtonClick(InputAction.CallbackContext obj)
    {
      if (EditorApplication.isPlaying)
      {
        EditorApplication.ExitPlaymode();
      }
    }
  }
}