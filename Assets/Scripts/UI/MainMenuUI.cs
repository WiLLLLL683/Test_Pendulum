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
        [SerializeField] private Button playButton;

        private SceneLoader sceneLoader;

        [Inject]
        public void Init(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;

            playButton.onClick.AddListener(Button_StartGame);
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveListener(Button_StartGame);
        }

        public void Button_StartGame()
        {
            sceneLoader.UnloadScene(GlobalConstants.MAIN_MENU_SCENE);
            sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);
        }
    }
}
