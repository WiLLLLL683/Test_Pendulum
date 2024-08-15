using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class GamePlayUI : MonoBehaviour
    {
        private StateMachine stateMachine;

        [Inject]
        public void Init(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Button_GameOver()
        {
            stateMachine.EnterState<GameOverState>();
        }
    }
}
