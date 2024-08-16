using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        
        private StateMachine stateMachine;
        private ScoreService scoreService;

        [Inject]
        public void Init(StateMachine stateMachine, ScoreService scoreService)
        {
            this.stateMachine = stateMachine;
            this.scoreService = scoreService;

            UpdateScoreText(scoreService.Score);
        }

        public void Button_Restart()
        {
            stateMachine.EnterState<GamePlayState>();
        }

        public void Button_Exit()
        {
            stateMachine.EnterState<MainMenuState>();
        }

        private void UpdateScoreText(int score) => scoreText.text = score.ToString();
    }
}
