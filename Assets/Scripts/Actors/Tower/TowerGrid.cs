using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Zenject;

namespace Test_Pendulum
{
    public class TowerGrid : MonoBehaviour
    {
        [SerializeField] private List<Tower> towers = new();
        [SerializeField] private int maxHeight;

        private StateMachine stateMachine;
        private Pattern[] patterns;

        [Inject]
        public void Init(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;

            patterns = new Pattern[]
            {
                Pattern.VerticalLine(0),
                Pattern.VerticalLine(1),
                Pattern.VerticalLine(2),
                Pattern.HorizontalLine(0),
                Pattern.HorizontalLine(1),
                Pattern.HorizontalLine(2),
                Pattern.DiagonalRise(),
                Pattern.DiagonalFall(),
            };

            for (int i = 0; i < towers.Count; i++)
            {
                towers[i].Init(maxHeight);
                towers[i].OnBallAdded += CheckMatch;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < towers.Count; i++)
            {
                towers[i].OnBallAdded -= CheckMatch;
            }
        }

        private void CheckMatch()
        {
            //finding matches
            List<Ball> match = new();

            for (int i = 0; i < patterns.Length; i++)
            {
                match.AddRange(patterns[i].Check(towers));
            }

            //destroying matched balls
            for (int i = 0; i < match.Count; i++)
            {
                for (int j = 0; j < towers.Count; j++)
                {
                    towers[j].DestroyBall(match[i]);
                }
            }

            CheckFull();
        }

        private void CheckFull()
        {
            //counting full towers
            int fullCount = 0;

            for (int i = 0; i < towers.Count; i++)
            {
                if (towers[i].IsFull)
                {
                    fullCount++;
                }
            }

            //GameOver check
            if (fullCount == towers.Count)
            {
                stateMachine.EnterState<GameOverState>();
            }
        }
    }
}