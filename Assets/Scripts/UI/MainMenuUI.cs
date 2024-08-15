using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class MainMenuUI : MonoBehaviour
    {
        private SceneLoader sceneLoader;

        [Inject]
        public void Init(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void Button_StartGame()
        {
            sceneLoader.UnloadScene(GlobalConstants.MAIN_MENU_SCENE);
            sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);
        }
    }
}
