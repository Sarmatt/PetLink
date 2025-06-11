using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class FeedingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
            => Debug.Log("Feeding");
    }
}