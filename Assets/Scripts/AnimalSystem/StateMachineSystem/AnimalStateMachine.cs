using AnimalSystem.StateMachineSystem.States;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AnimalSystem.StateMachineSystem
{
    public class AnimalStateMachine : MonoBehaviour
    {
        [Title("Main Values")] [SerializeField]
        private Vector2 _waitingTime = new Vector2(0.1f, 10f);

        [SerializeField] private bool _isDebugMode = false;

        private BaseAnimalState _currentState = null;

        public float RandomWaitingTime => Random.Range(_waitingTime.x, _waitingTime.y);

        private void Start()
            => SetNextState();
        
        private void SetState(BaseAnimalState newState)
        {
            if (_isDebugMode)
                Debug.Log($"{nameof(SetState)}: {newState}");
            _currentState?.Break();

            _currentState = newState;
            _currentState.Init(this);
        }

        public void SetNextState()
        {
            SetState(new IdleAnimalState());
        }
    }
}