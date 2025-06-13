using Core;
using Systems.FirebaseSystem;
using UnityEngine;

namespace Systems.AnimalSystem.AnimalNeedsSystem
{
    public class AnimalNeedsContainer : MonoBehaviour
    {
        [SerializeField] private BaseAnimalNeedSystem _hungryNeedSystem;
        [SerializeField] private BaseAnimalNeedSystem _thirstyNeedSystem;
        [SerializeField] private BaseAnimalNeedSystem _sleepNeedSystem;
        [SerializeField] private BaseAnimalNeedSystem _happinessNeedSystem;

        private void OnEnable()
        {
            _hungryNeedSystem.OnHalfPointsReached += HandleDataChange;
            _hungryNeedSystem.OnZeroPointsReached += HandleDataChange;
            _thirstyNeedSystem.OnHalfPointsReached += HandleDataChange;
            _thirstyNeedSystem.OnZeroPointsReached += HandleDataChange;
            _sleepNeedSystem.OnHalfPointsReached += HandleDataChange;
            _sleepNeedSystem.OnZeroPointsReached += HandleDataChange;
            _happinessNeedSystem.OnHalfPointsReached += HandleDataChange;
            _happinessNeedSystem.OnZeroPointsReached += HandleDataChange;
        }
        
        private void OnDisable()
        {
            _hungryNeedSystem.OnHalfPointsReached -= HandleDataChange;
            _hungryNeedSystem.OnZeroPointsReached -= HandleDataChange;
            _thirstyNeedSystem.OnHalfPointsReached -= HandleDataChange;
            _thirstyNeedSystem.OnZeroPointsReached -= HandleDataChange;
            _sleepNeedSystem.OnHalfPointsReached -= HandleDataChange;
            _sleepNeedSystem.OnZeroPointsReached -= HandleDataChange;
            _happinessNeedSystem.OnHalfPointsReached -= HandleDataChange;
            _happinessNeedSystem.OnZeroPointsReached -= HandleDataChange;
        }

        private void HandleDataChange()
        {
            AnimalWebData data = new();

            data.IsHungry = _hungryNeedSystem.IsHalf || _hungryNeedSystem.IsZero;
            data.IsThirsty = _thirstyNeedSystem.IsHalf || _thirstyNeedSystem.IsZero;
            data.NeeedSleep = _sleepNeedSystem.IsHalf || _sleepNeedSystem.IsZero;
            data.NeedHappines = _happinessNeedSystem.IsHalf || _happinessNeedSystem.IsZero;
            
            GlobalEventsContainer.OnAnimalDataChanged?.Invoke(data);
        }
    }
}