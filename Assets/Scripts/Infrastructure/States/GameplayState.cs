using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class GamePlayState : IState
    {
        private readonly SceneLoader sceneLoader;
        private readonly Input input;
        private readonly ScoreService scoreService;
        private Pendulum pendulum;

        public GamePlayState(SceneLoader sceneLoader, Input input, ScoreService scoreService)
        {
            this.sceneLoader = sceneLoader;
            this.input = input;
            this.scoreService = scoreService;
        }

        public IEnumerator OnEnter()
        {
            sceneLoader.UnloadScene(GlobalConstants.MAIN_MENU_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            yield return sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);

            scoreService.Reset();
            input.Enable();
            pendulum = GameObject.FindObjectOfType<Pendulum>();
            pendulum?.Enable();
        }

        public void OnExit()
        {
            pendulum?.Disable();
            input.Disable();
        }

        public void OnUpdate()
        {

        }
    }
}