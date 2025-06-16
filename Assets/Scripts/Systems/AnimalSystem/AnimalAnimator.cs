using Sirenix.OdinInspector;
using UnityEngine;

namespace Systems.AnimalSystem.AnimationSystem
{
    public class AnimalAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static string _walkingState = "Walking";
        private static string _drinkingState = "Drinking";
        private static string _feedingState = "Eating";
        private static string _sleepingState = "Sleeping";
        private static string _sittingState = "Sitting";
        
        [Button]
        public void SetWalkingState(bool isWalking)
        {
            _animator.SetBool(_walkingState, isWalking);
        }
        
        [Button]
        public void SetDrinkingState(bool isDrinking)
        {
            _animator.SetBool(_drinkingState, isDrinking);
        }
        
        [Button]
        public void SetFeedingState(bool isFeeding)
        {
            _animator.SetBool(_feedingState, isFeeding);
        }
        
        [Button]
        public void SetSleepingState(bool isSleeping)
        {
            _animator.SetBool(_sleepingState, isSleeping);
        }
        
        [Button]
        public void SetSittingState(bool isIdle)
        {
            _animator.SetBool(_sittingState, isIdle);
        }
    }
}