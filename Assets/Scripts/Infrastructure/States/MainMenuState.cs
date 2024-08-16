using System;
using System.Collections;
using Test_Pendulum;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class MainMenuState : IState
    {
        private readonly SceneLoader sceneLoader;
        private BallInfiniteSpawner ballSpawner;

        public MainMenuState(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public IEnumerator OnEnter()
        {
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            yield return sceneLoader.LoadScene(GlobalConstants.MAIN_MENU_SCENE);

            ballSpawner = GameObject.FindObjectOfType<BallInfiniteSpawner>();
            ballSpawner?.Enable();
        }

        public void OnExit()
        {
            ballSpawner?.Disable();
            ballSpawner?.DestroyAll();
        }

        public void OnUpdate()
        {

        }
    }
}