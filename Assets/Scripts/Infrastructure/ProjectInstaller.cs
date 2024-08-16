using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private Ball ballPrefab;
        [SerializeField] private List<BallConfig> ballConfigs = new();

        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<Input>().AsSingle();
            Container.Bind<ConfigProvider>().FromInstance(new ConfigProvider(ballConfigs, ballPrefab)).AsSingle();
            Container.Bind<BallSpawner>().AsSingle();
        }
    }
}