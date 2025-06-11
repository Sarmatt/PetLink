using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class IdleAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
            => Debug.Log("Idle");
    }
}