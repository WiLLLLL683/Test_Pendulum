using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class GamePlayUI : MonoBehaviour
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

            scoreService.OnChange += UpdateScoreText;
        }

        private void OnDestroy()
        {
            scoreService.OnChange -= UpdateScoreText;
        }

        public void Button_GameOver() => stateMachine.EnterState<GameOverState>();
        private void UpdateScoreText(int score) => scoreText.text = score.ToString();
    }
}
