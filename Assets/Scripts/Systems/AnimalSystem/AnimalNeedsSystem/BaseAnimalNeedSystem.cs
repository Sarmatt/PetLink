using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Systems.AnimalSystem.AnimalNeedsSystem
{
    public class BaseAnimalNeedSystem : MonoBehaviour
    {
        [Title("Base Need Parameters")] [Range(1, 1000)] [SerializeField]
        private int _defaultNeedPointsCount = 100;
        
        public Action OnZeroPointsReached { get; set; }
        public Action OnHalfPointsReached { get; set; }
        public Action OnFullPointsReached { get; set; }
        
        private int _currentNeedPointsCount;
        
        public bool IsHalf => _currentNeedPointsCount <= _defaultNeedPointsCount / 2;
        public bool IsFull => _currentNeedPointsCount >= _defaultNeedPointsCount;
        public bool IsZero => _currentNeedPointsCount <= 0;

        private void Start()
        {
            RestorePoints();
            StartCoroutine(RemovePointPerSecond());
        }

        public void RestorePoints()
        {
            _currentNeedPointsCount = _defaultNeedPointsCount;
            CheckRemainingPoints();
        }

        private void RemovePoint()
        {
            _currentNeedPointsCount--;
            if(_currentNeedPointsCount <= 0)
                _currentNeedPointsCount = 0;
            CheckRemainingPoints();
        }

        private void CheckRemainingPoints()
        {
            var pointsPercent = _currentNeedPointsCount / _defaultNeedPointsCount;

            if (IsZero)
                OnZeroPointsReached?.Invoke();
            else if (IsHalf)
                OnFullPointsReached?.Invoke();
            else if(IsFull)
                OnHalfPointsReached?.Invoke();
        }
        
        private IEnumerator RemovePointPerSecond()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                RemovePoint();
            }
        }
    }
}