using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class BallFollowAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
            => Debug.Log("BallFollow");
    }
}