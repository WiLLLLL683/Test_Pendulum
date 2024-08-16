using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Test_Pendulum
{
    public class Tower : MonoBehaviour
    {
        public Ball[] Balls { get; private set; }
        public bool IsFull { get; private set; }

        public event Action OnBallAdded;

        public void Init(int maxBalls)
        {
            Balls = new Ball[maxBalls];
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.TryGetComponent(out Ball ball))
                return;
            if (ball.IsInTower)
                return;
            if (collision.attachedRigidbody.velocity.sqrMagnitude > 0.1f)
                return;

            AddBall(ball);
        }

        public void AddBall(Ball ball)
        {
            if (IsFull || !TryFindFirstEmptyIndex(out int index))
                return;

            ball.SetInTower(true);
            Balls[index] = ball;
            OnBallAdded?.Invoke();
        }

        public void DestroyBall(Ball ball)
        {
            if (!TryFindBall(ball, out int index))
                return;

            Balls[index].Destroy();
            Balls[index] = null;
            MoveBallsDownInArray();
        }

        public bool TryFindBall(Ball ball, out int index)
        {
            for (int i = 0; i < Balls.Length; i++)
            {
                if (ball == Balls[i])
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        private bool TryFindFirstEmptyIndex(out int index)
        {
            for (int i = 0; i < Balls.Length; i++)
            {
                if (Balls[i] == null)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            IsFull = true;
            return false;
        }

        private void MoveBallsDownInArray()
        {
            for (int i = 0; i < Balls.Length - 1; i++)
            {
                if (Balls[i] == null)
                {
                    Balls[i] = Balls[i + 1];
                    Balls[i + 1] = null;
                }
            }
        }
    }
}