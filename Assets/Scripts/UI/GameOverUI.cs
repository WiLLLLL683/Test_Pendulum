using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class GameOverUI : MonoBehaviour
    {
        private SceneLoader sceneLoader;

        [Inject]
        public void Init(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void Button_Restart()
        {
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);
        }

        public void Button_Exit()
        {
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            sceneLoader.LoadScene(GlobalConstants.MAIN_MENU_SCENE);
        }
    }
}
