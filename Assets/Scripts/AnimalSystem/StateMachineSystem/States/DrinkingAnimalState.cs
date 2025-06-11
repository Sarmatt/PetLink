using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class DrinkingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
            => Debug.Log("Dead");
    }
}