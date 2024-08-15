using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader;

        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
        }
    }
}