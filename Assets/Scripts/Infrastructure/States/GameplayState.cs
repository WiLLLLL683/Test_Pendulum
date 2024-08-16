using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class GamePlayState : IState
    {
        private SceneLoader sceneLoader;
        private Pendulum pendulum;

        public GamePlayState(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public IEnumerator OnEnter()
        {
            sceneLoader.UnloadScene(GlobalConstants.MAIN_MENU_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            yield return sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);

            pendulum = GameObject.FindObjectOfType<Pendulum>();
            pendulum?.Enable();
        }

        public void OnExit()
        {
            pendulum?.Disable();
        }

        public void OnUpdate()
        {

        }
    }
}