using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.AnimalSystem.AnimalNeedsSystem
{
    public class BaseAnimalNeedsView : MonoBehaviour
    {
        [Title("Main Values")] [SerializeField]
        private BaseAnimalNeedSystem _targetSystem;

        [Header("UI")] [SerializeField] private Image _targetImage;
        [SerializeField] private Color _halfPointsColor = Color.yellow;
        [SerializeField] private Color _zeroPointsColor = Color.red;

        private void Start()
        {
            _targetSystem.OnZeroPointsReached += OnZeroPointsReached;
            _targetSystem.OnHalfPointsReached += OnHalfPointsReached;
            _targetSystem.OnFullPointsReached += OnFullPointsReached;
        }

        private void HandleImageActive(bool isActive)
            => _targetImage.gameObject.SetActive(isActive);

        private void OnZeroPointsReached()
        {
            HandleImageActive(true);
            _targetImage.color = _zeroPointsColor;
        }

        private void OnHalfPointsReached()
        {
            HandleImageActive(true);
            _targetImage.color = _halfPointsColor;
        }

        private void OnFullPointsReached()
            => HandleImageActive(false);
    }
}