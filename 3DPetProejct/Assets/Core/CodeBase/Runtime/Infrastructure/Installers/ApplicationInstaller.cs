using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Infrastructure.Installers
{
  public class ApplicationInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Application.targetFrameRate = 60;
      
      Container
        .Bind<IPlayerInput>()
        .To<PlayerInput>()
        .AsSingle();
    }

    public override void Start()
    {
      base.Start();
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }
  }
}