using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class GamePlayUI : MonoBehaviour
    {
        private SceneLoader sceneLoader;

        [Inject]
        public void Init(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void Button_GameOver()
        {
            sceneLoader.LoadScene(GlobalConstants.GAME_OVER_SCENE, showLoadScreen: false);
        }
    }
}
