using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Systems.PrefabsPlacingSystem
{
    public class ObjectPlacer : MonoBehaviour
    {
        [Title("Placing Pref")] [SerializeField]
        private List<GameObject> _prefabsPool;
        
        private GameObject _spawnedPref;

        private bool _isMoving;

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
                StartMoving();
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
                StopMoving();

            if (_isMoving)
                CastRay();
        }

        private void CastRay()
        {
            var rayOrigin = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            var rayDirection = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward;

            var anchorHit = default(MRUKAnchor);

            var hit = default(RaycastHit);
            var room = MRUK.Instance.GetCurrentRoom();

            if (!room.Raycast(new Ray(rayOrigin, rayDirection), Mathf.Infinity,
                    out hit, out anchorHit))
                return;

            if (!_spawnedPref)
            {
                _spawnedPref = Instantiate(_prefabsPool[0]);
                _prefabsPool.RemoveAt(0);
            }

            var rotation = Quaternion.LookRotation(-hit.normal);
            _spawnedPref.transform.SetPositionAndRotation(hit.point, rotation);
        }

        private void StartMoving()
        {
            if(_prefabsPool.Count == 0) return;
            _isMoving = true;
        }

        private void StopMoving()
        {
            _isMoving = false;
            if (!_spawnedPref) return;
            _spawnedPref = null;
        }
    }
}