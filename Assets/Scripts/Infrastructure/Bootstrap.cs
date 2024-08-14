using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Test_Pendulum
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;

        private void Awake()
        {
            sceneLoader.LoadScene(GlobalConstants.MAIN_MENU_SCENE);
        }
    }
}