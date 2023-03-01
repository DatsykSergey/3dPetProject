using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Infrastructure.Installers
{
  public class GameplayInstaller : MonoBehaviour
  {
    [SerializeField] private Transform _camera;

    [Inject]
    private void Construct(IPlayerInput input)
    {
      input.SetPlayerCamera(_camera);
    }
  }
}