using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Utils
{
    public class StateMachine
    {
        public IExitableState CurrentState { get; private set; }

        private readonly Dictionary<Type, IExitableState> states = new();
        private readonly CoroutineRunner coroutineRunner;

        private Coroutine coroutine;

        public StateMachine(CoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }

        public void EnterState<T>() where T : IState
        {
            if (coroutine != null)
                coroutineRunner.StopCoroutine(coroutine);

            coroutine = coroutineRunner.StartCoroutine(EnterStateRoutine<T>());
        }

        public void AddState(IExitableState state)
        {
            Type type = state.GetType();
            states[type] = state;
        }

        public T GetState<T>() where T : IExitableState
        {
            if (!states.ContainsKey(typeof(T)))
            {
                Debug.LogError("Can't get state: " + typeof(T) + " - StateMachine doesn't contain this state");
                return default;
            }

            return (T)states[typeof(T)];
        }

        public void Update() => CurrentState.OnUpdate();

        private IEnumerator EnterStateRoutine<T>() where T : IState
        {
            T newState = GetState<T>();
            if (newState == null)
                yield break;

            ChangeState(newState);
            yield return newState.OnEnter();
        }

        private void ChangeState(IExitableState newState)
        {
            CurrentState?.OnExit();
            CurrentState = newState;
        }
    }
}