using Cinemachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Services.Input
{
  public class CinemachineInputAdapter : MonoBehaviour
  {
    [SerializeField] private CinemachineFreeLook _freeLook;
    private IPlayerInput _input;

    [Inject]
    private void Construct(IPlayerInput input)
    {
      _input = input;
    }

    private void LateUpdate()
    {
      Vector2 lookDelta = _input.GetLookDelta();
      _freeLook.m_XAxis.Value += lookDelta.x;
      lookDelta.Normalize();
      _freeLook.m_YAxis.Value -= lookDelta.y / 100;
    }
  }
}