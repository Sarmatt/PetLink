using System.Collections;
using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class IdleAnimalState : BaseAnimalState
    {
        private Coroutine _waitingRoutine;
        
        protected override void OnEnter()
        {
            base.OnEnter();
            _waitingRoutine = StateMachine.StartCoroutine(WaitingRoutine());
        }
        
        protected override void OnExit()
            => StateMachine.SetNextState();

        public override void Break()
        {
            base.Break();
            StateMachine.StopCoroutine(_waitingRoutine);
        }
        
        private IEnumerator WaitingRoutine()
        {
            yield return new WaitForSeconds(StateMachine.RandomWaitingTime);
            OnExit();
        }
    }
}