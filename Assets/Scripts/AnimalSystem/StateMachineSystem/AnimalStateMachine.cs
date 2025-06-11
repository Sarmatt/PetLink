using AnimalSystem.StateMachineSystem.States;
using UnityEngine;

namespace AnimalSystem.StateMachineSystem
{
    public class AnimalStateMachine : MonoBehaviour
    {
        private BaseAnimalState _currentState = null;
        
        public void SetState(BaseAnimalState newState)
        {
            _currentState?.OnExit();

            _currentState = newState;
            _currentState.Init(this);
        }
    }
}