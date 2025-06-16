using UnityEngine;

namespace Systems.AnimalSystem.StateMachineSystem.States
{
    public class AnimalSitState : BaseAnimalState
    {
        protected override void OnEnter()
        {
            Debug.Log(nameof(OnEnter));
            StateMachine.AnimalAnimator.SetSittingState(true);
        }

        public override void Break()
        {
            Debug.Log(nameof(Break));
            StateMachine.AnimalAnimator.SetSittingState(false);
        }
    }
}