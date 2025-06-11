using System.Collections;
using Systems.ObjectsPlacingSystem;
using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class SleepingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            if (!PlacedObjectsFabric.Singleton.TryGetPlacedObject(out SleepingPlacingObject sleepingPlacingObject))
            {
                Debug.Log("Sleeper not found");
                OnExit();
                return;
            }
            
            StateMachine.MoveTo(sleepingPlacingObject.transform.position, HandleAnimalSleep);
        }

        private void HandleAnimalSleep()
        {
            Debug.Log("Sleeping");
            StateMachine.StartCoroutine(SleepingRoutine());
        }

        private IEnumerator SleepingRoutine()
        {
            yield return new WaitForSeconds(StateMachine.SleepingTime);
            OnExit();
        }
    }
}