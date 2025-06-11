using System.Collections;
using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class IdleAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            StateMachine.StartCoroutine(WaitingRoutine());
        }

        private IEnumerator WaitingRoutine()
        {
            yield return new WaitForSeconds(StateMachine.RandomWaitingTime);
            OnExit();
        }
    }
}