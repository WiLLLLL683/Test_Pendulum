using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Pendulum
{
    public class Input
    {
        public event Action OnRelease;

        private GameActions actions;

        public Input()
        {
            actions = new GameActions();
        }

        public void Enable()
        {
            actions.Enable();
            actions.GamePlay.ReleaseBall.performed += ctx => OnRelease?.Invoke();
        }

        public void Disable()
        {
            actions.GamePlay.ReleaseBall.performed -= ctx => OnRelease?.Invoke();
            actions.Disable();
        }
    }
}