using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Test_Pendulum
{
    public class Pattern
    {
        public Vector2Int[] coordsToCheck;

        public static Pattern VerticalLine(int x)
        {
            return new()
            {
                coordsToCheck = new[]
                {
                    new Vector2Int(x, 0),
                    new Vector2Int(x, 1),
                    new Vector2Int(x, 2),
                }
            };
        }

        public static Pattern HorizontalLine(int y)
        {
            return new()
            {
                coordsToCheck = new[]
                {
                    new Vector2Int(0, y),
                    new Vector2Int(1, y),
                    new Vector2Int(2, y),
                }
            };
        }

        public static Pattern DiagonalRise()
        {
            return new()
            {
                coordsToCheck = new[]
                {
                    new Vector2Int(0, 0),
                    new Vector2Int(1, 1),
                    new Vector2Int(2, 2),
                }
            };
        }

        public static Pattern DiagonalFall()
        {
            return new()
            {
                coordsToCheck = new[]
                {
                    new Vector2Int(0, 2),
                    new Vector2Int(1, 1),
                    new Vector2Int(2, 0),
                }
            };
        }

        public List<Ball> Check(List<Tower> towers)
        {
            List<Ball> match = new();
            Vector2Int refCoords = coordsToCheck[0];
            Ball refBall = towers[refCoords.x].Balls[refCoords.y];

            if (refBall == null)
                return match;

            match.Add(refBall);

            for (int j = 1; j < coordsToCheck.Length; j++)
            {
                Vector2Int coords = coordsToCheck[j];
                Ball ball = towers[coords.x].Balls[coords.y];

                if (ball == null || ball.Id != refBall.Id)
                {
                    match.Clear();
                    return match;
                }

                match.Add(ball);
            }

            return match;
        }
    }
}