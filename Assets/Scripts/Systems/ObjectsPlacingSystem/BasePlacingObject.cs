using UnityEngine;

namespace Systems.ObjectsPlacingSystem
{
    public class BasePlacingObject : MonoBehaviour
    {
        private void Start()
            => PlacedObjectsFabric.Singleton.AddPlacedObject(this);
    }
}