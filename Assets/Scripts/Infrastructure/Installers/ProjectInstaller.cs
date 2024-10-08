using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private Ball ballPrefab;
        [SerializeField] private Ball ballWithTimerPrefab;
        [SerializeField] private List<BallConfig> ballConfigs = new();
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private AudioMixerGroup sfxAudioGroup;

        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
            Container.Bind<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
            Container.Bind<Input>().AsSingle();
            Container.Bind<ConfigProvider>().FromInstance(new ConfigProvider(ballConfigs, ballPrefab, ballWithTimerPrefab, gameOverSound)).AsSingle();
            Container.Bind<ScoreService>().AsSingle();
            Container.Bind<AudioService>().FromInstance(new(sfxAudioGroup)).AsSingle();
        }
    }
}