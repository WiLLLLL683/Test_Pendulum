using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class Bootstrap : MonoBehaviour
    {
        private StateMachine stateMachine;
        private StateFactory stateFactory;

        [Inject]
        public void Init(StateMachine stateMachine, StateFactory stateFactory)
        {
            this.stateMachine = stateMachine;
            this.stateFactory = stateFactory;
        }

        private void Awake()
        {
            stateMachine.AddState(stateFactory.Create<MainMenuState>());
            stateMachine.AddState(stateFactory.Create<GamePlayState>());
            stateMachine.AddState(stateFactory.Create<GameOverState>());

            stateMachine.EnterState<MainMenuState>();
        }
    }
}