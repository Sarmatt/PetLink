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

            if (pointsPercent <= 0)
                OnZeroPointsReached?.Invoke();
            else if (pointsPercent <= 0.5f)
                OnFullPointsReached?.Invoke();
            else
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