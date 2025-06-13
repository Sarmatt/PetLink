using UnityEngine;

namespace Systems.FirebaseSystem
{
    [System.Serializable]
    public class AnimalWebData
    {
        [SerializeField] private bool _isThirsty;
        [SerializeField] private bool _isHungry;
        [SerializeField] private bool _neeedSleep;
        [SerializeField] private bool _needHappines;

        public bool IsThirsty
        {
            get => _isThirsty;
            set => _isThirsty = value;
        }

        public bool IsHungry
        {
            get => _isHungry;
            set => _isHungry = value;
        }

        public bool NeeedSleep
        {
            get => _neeedSleep;
            set => _neeedSleep = value;
        }

        public bool NeedHappines
        {
            get => _needHappines;
            set => _needHappines = value;
        }
    }
}