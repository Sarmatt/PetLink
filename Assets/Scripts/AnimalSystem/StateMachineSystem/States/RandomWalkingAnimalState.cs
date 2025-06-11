using Systems;
using UnityEngine;

namespace AnimalSystem.StateMachineSystem.States
{
    public class RandomWalkingAnimalState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            if (!RandomPositionFinder.TryGetNavMeshRandomPoint(StateMachine.transform.position,
                    StateMachine.SampleRadius, StateMachine.MaxAttempts, out var targetPoint))
            {
                Debug.Log("Can't find random point");
                OnExit();
                return;
            }

            StateMachine.MoveTo(targetPoint, OnExit);
        }
    }
}