using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class GameOverUI : MonoBehaviour
    {
        private StateMachine stateMachine;

        [Inject]
        public void Init(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Button_Restart()
        {
            stateMachine.EnterState<GamePlayState>();
        }

        public void Button_Exit()
        {
            stateMachine.EnterState<MainMenuState>();
        }
    }
}
