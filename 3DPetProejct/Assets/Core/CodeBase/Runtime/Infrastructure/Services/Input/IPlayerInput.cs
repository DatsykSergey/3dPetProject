using UnityEngine;

namespace CodeBase.Runtime.Infrastructure.Services.Input
{
  public interface IPlayerInput
  {
    void SetPlayerCamera(Transform camera);
    Vector2 GetMoveDirection();
    Vector2 GetLookDelta();
    Vector3 GetCameraRelativeMoveDirection();
    bool IsPressJump();
  }
}