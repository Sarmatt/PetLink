using UnityEngine;

namespace Systems.UISystem
{
    public class UICameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;

        private Camera _camera;

        private void Start()
            => _camera = Camera.main;

        private void Update()
        {
            transform.LookAt(_camera.transform.position);
            transform.eulerAngles += _offset;
        }
    }
}