using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class GamePlayState : IState
    {
        private SceneLoader sceneLoader;
        private readonly Input input;
        private Pendulum pendulum;

        public GamePlayState(SceneLoader sceneLoader, Input input)
        {
            this.sceneLoader = sceneLoader;
            this.input = input;
        }

        public IEnumerator OnEnter()
        {
            sceneLoader.UnloadScene(GlobalConstants.MAIN_MENU_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            yield return sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);

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