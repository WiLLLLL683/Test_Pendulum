using Zenject;

namespace Test_Pendulum
{
    public class GamePlayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BallFactory>().AsSingle();
        }
    }
}