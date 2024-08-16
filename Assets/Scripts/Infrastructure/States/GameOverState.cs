using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class GameOverState : IState
    {
        private SceneLoader sceneLoader;
        private readonly ConfigProvider configProvider;
        private readonly AudioService audioService;

        public GameOverState(SceneLoader sceneLoader, ConfigProvider configProvider, AudioService audioService)
        {
            this.sceneLoader = sceneLoader;
            this.configProvider = configProvider;
            this.audioService = audioService;
        }

        public IEnumerator OnEnter()
        {
            yield return sceneLoader.LoadScene(GlobalConstants.GAME_OVER_SCENE, showLoadScreen: false);

            audioService.PlaySFX(configProvider.GameOverSound, Vector3.zero);
        }

        public void OnExit()
        {

        }

        public void OnUpdate()
        {

        }
    }
}