using System.Collections;
using Systems.ObjectsPlacingSystem;
using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class FeedingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            if (!PlacedObjectsFabric.Singleton.TryGetPlacedObject(out FeederPlacingObject feederPlacingObject))
            {
                Debug.Log("Feeding not found");
                OnExit();
                return;
            }
            
            StateMachine.MoveTo(feederPlacingObject.transform.position, HandleAnimalFeeding);
        }

        private void HandleAnimalFeeding()
        {
            Debug.Log("Feeding");
            StateMachine.StartCoroutine(FeederRoutine());
        }

        private IEnumerator FeederRoutine()
        {
            yield return new WaitForSeconds(StateMachine.SleepingTime);
            OnExit();
        }
    }
}