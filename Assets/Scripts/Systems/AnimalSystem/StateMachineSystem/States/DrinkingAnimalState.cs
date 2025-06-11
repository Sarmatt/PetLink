using System.Collections;
using Systems.ObjectsPlacingSystem;
using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class DrinkingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            if (!PlacedObjectsFabric.Singleton.TryGetPlacedObject(out DrinkerPlacingObject drinkerPlacingObject))
            {
                Debug.Log("Drinker not found");
                OnExit();
                return;
            }
            
            StateMachine.MoveTo(drinkerPlacingObject.transform.position, HandleAnimalDrink);
        }

        private void HandleAnimalDrink()
        {
            Debug.Log("Drinking");
            StateMachine.StartCoroutine(DrinkingRoutine());
        }

        private IEnumerator DrinkingRoutine()
        {
            yield return new WaitForSeconds(StateMachine.DrinkingTime);
            OnExit();
        }
    }
}