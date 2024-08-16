using System;
using System.Collections;
using Test_Pendulum;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class MainMenuState : IState
    {
        private SceneLoader sceneLoader;

        public MainMenuState(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public IEnumerator OnEnter()
        {
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            yield return sceneLoader.LoadScene(GlobalConstants.MAIN_MENU_SCENE);
        }

        public void OnExit()
        {

        }

        public void OnUpdate()
        {

        }
    }
}