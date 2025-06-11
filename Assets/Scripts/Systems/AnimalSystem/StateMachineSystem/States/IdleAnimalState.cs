using System.Collections;
using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class IdleAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            StateMachine.StartCoroutine(WaitingRoutine());
        }
        
        protected override void OnExit()
            => StateMachine.SetNextState();

        private IEnumerator WaitingRoutine()
        {
            yield return new WaitForSeconds(StateMachine.RandomWaitingTime);
            OnExit();
        }
    }
}