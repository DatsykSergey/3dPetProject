using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using Zenject;

namespace Core.CodeBase.Runtime.Infrastructure.Installers
{
  public class ApplicationInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container
        .Bind<IPlayerInput>()
        .To<PlayerInput>()
        .AsSingle();
    }
  }
}