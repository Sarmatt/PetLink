using System;
using System.Collections;
using Sirenix.OdinInspector;
using Systems.AnimalSystem.AnimalNeedsSystem;
using Systems.AnimalSystem.AnimationSystem;
using Systems.AnimalSystem.StateMachineSystem.States;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Systems.AnimalSystem.StateMachineSystem
{
    public class AnimalStateMachine : MonoBehaviour
    {
        [Title("Attached Components")] [SerializeField]
        private NavMeshAgent _navMeshAgent;
        [SerializeField] private AnimalSoundSpawner _animalSoundSpawner;
        [SerializeField] private AnimalAnimator _animalAnimator;
        
        [Title("Statess")]
        [SerializeField] private BaseAnimalNeedSystem _sleepNeedSystem;
        [SerializeField] private BaseAnimalNeedSystem _drinkingNeedSystem;
        [SerializeField] private BaseAnimalNeedSystem _eatingNeedSystem;
        [SerializeField] private BaseAnimalNeedSystem _funNeedSystem;

        [TabGroup("Idle State")] [SerializeField]
        private Vector2 _waitingTime = new Vector2(0.1f, 10f);

        [TabGroup("Random Walking State")] [SerializeField]
        private float _sampleRadius = 20f;

        [TabGroup("Random Walking State")] [SerializeField]
        private int _maxAttempts = 30;
        
        [TabGroup("Sleeping State")] [SerializeField]
        private float _sleepingTime = 1f;

        private BaseAnimalState _currentState = null;

        public AnimalAnimator AnimalAnimator => _animalAnimator;
        public AnimalSoundSpawner AnimalSoundSpawner => _animalSoundSpawner;
        public float RandomWaitingTime => Random.Range(_waitingTime.x, _waitingTime.y);
        public float SampleRadius => _sampleRadius;
        public int MaxAttempts => _maxAttempts;
        public float DrinkingTime => AnimalSoundSpawner.DrinkSound.length;
        public float EatingTime => AnimalSoundSpawner.EatSound.length;
        public float SleepingTime => _sleepingTime;

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
            _animalAnimator.SetWalkingState(true);
            TryRepositionNavMesh();
            SetAgentStopped(true);
            _navMeshAgent.SetDestination(targetPoint);
            SetAgentStopped(false);
            _navMeshAgent.stoppingDistance = 0.1f;

            while (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
                yield return null;
                        
            _animalAnimator.SetWalkingState(false);
            onArrived?.Invoke();
        }

        public void MoveTo(Vector3 targetPoint, Action onArrived)
            => StartCoroutine(MoveToRoutine(targetPoint, onArrived));

        public void SetNextState()
        {
            if(!_drinkingNeedSystem.IsFull)
                SetState(new DrinkingAnimalState());
            else if(!_sleepNeedSystem.IsFull)
                SetState(new SleepingAnimalState());
            else if(!_eatingNeedSystem.IsFull)
                SetState(new FeedingAnimalState());
            else
                SetState(new RandomWalkingAnimalState());
        }

        public void SetDefaultState()
        {
            SetState(new IdleAnimalState());
        }
        
        private void SetAgentStopped(bool isStopped)
        {
            Debug.Log($"{nameof(SetAgentStopped)} {isStopped}");
            _navMeshAgent.isStopped = isStopped;
        }
    }
}