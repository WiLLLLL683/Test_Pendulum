using System;
using Utils;

namespace Test_Pendulum
{
    public class GamePlayState : IState
    {
        private SceneLoader sceneLoader;

        public GamePlayState(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void OnEnter()
        {
            sceneLoader.UnloadScene(GlobalConstants.MAIN_MENU_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAMEPLAY_SCENE);
            sceneLoader.UnloadScene(GlobalConstants.GAME_OVER_SCENE);
            sceneLoader.LoadScene(GlobalConstants.GAMEPLAY_SCENE);
        }

        public void OnExit()
        {

        }

        public void OnUpdate()
        {

        }
    }
}