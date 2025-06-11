using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class WalkingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
            => Debug.Log("Walking");
    }
}