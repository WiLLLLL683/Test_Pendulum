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
        private StateMachine stateMachine;

        [Inject]
        public void Init(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Button_StartGame()
        {
            stateMachine.EnterState<GamePlayState>();
        }
    }
}
