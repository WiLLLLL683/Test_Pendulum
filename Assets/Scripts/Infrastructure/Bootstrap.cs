using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;

        [Inject]
        public void Init(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            sceneLoader.LoadScene(GlobalConstants.MAIN_MENU_SCENE);
        }
    }
}