using System;
using System.Collections;
using AnimalSystem.StateMachineSystem.States;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace AnimalSystem.StateMachineSystem
{
    public class AnimalStateMachine : MonoBehaviour
    {
        [Title("Attached Components")] [SerializeField]
        private NavMeshAgent _navMeshAgent;

        [TabGroup("Idle State")] [SerializeField]
        private Vector2 _waitingTime = new Vector2(0.1f, 10f);

        [TabGroup("Random Walking State")] [SerializeField]
        private float _sampleRadius = 20f;

        [TabGroup("Random Walking State")] [SerializeField]
        private int _maxAttempts = 30;

        private BaseAnimalState _currentState = null;

        public float RandomWaitingTime => Random.Range(_waitingTime.x, _waitingTime.y);
        public float SampleRadius => _sampleRadius;
        public int MaxAttempts => _maxAttempts;

        private void Start()
            => SetDefaultState();

        private void TryRepositionNavMesh()
        {
            if (_navMeshAgent.isOnNavMesh) return;

            SetAgentStopped(true);
            if (!NavMesh.SamplePosition(transform.position, out var hit, 1.0f, NavMesh.AllAreas)) return;
            _navMeshAgent.Warp(hit.position);
            SetAgentStopped(false);
        }

        private void SetState(BaseAnimalState newState)
        {
            Debug.Log($"{nameof(SetState)} {newState.GetType().Name}");

            _currentState?.Break();

            _currentState = newState;
            _currentState.Init(this);
        }

        private IEnumerator MoveToRoutine(Vector3 targetPoint, Action onArrived)
        {
            TryRepositionNavMesh();
            SetAgentStopped(true);
            _navMeshAgent.SetDestination(targetPoint);
            SetAgentStopped(false);
            _navMeshAgent.stoppingDistance = 0.1f;

            while (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
                yield return null;
                        
            onArrived?.Invoke();
        }

        public void MoveTo(Vector3 targetPoint, Action onArrived)
            => StartCoroutine(MoveToRoutine(targetPoint, onArrived));

        public void SetNextState()
        {
            SetState(new RandomWalkingAnimalState());
        }

        public void SetDefaultState()
        {
            SetState(new IdleAnimalState());
        }

        [Button]
        private void SetRandomWalking()
            => SetState(new RandomWalkingAnimalState());

        [Button]
        private void SetAgentStopped(bool isStopped)
        {
            Debug.Log($"{nameof(SetAgentStopped)} {isStopped}");
            _navMeshAgent.isStopped = isStopped;
        }
    }
}