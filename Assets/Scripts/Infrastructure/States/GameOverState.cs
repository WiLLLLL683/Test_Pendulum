using System;
using Utils;

namespace Test_Pendulum
{
    public class GameOverState : IState
    {
        private SceneLoader sceneLoader;

        public GameOverState(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void OnEnter()
        {
            sceneLoader.LoadScene(GlobalConstants.GAME_OVER_SCENE, showLoadScreen: false);
        }

        public void OnExit()
        {

        }

        public void OnUpdate()
        {

        }
    }
}