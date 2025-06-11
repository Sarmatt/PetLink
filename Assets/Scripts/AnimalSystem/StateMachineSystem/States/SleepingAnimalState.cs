using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class SleepingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
            => Debug.Log("Sleeping");
    }
}