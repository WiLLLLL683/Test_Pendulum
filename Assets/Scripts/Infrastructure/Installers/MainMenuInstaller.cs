using Zenject;

namespace Test_Pendulum
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BallFactory>().AsSingle();
            Container.Bind<VFXFactory>().AsSingle();
        }
    }
}