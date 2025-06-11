using System.Collections.Generic;
using UnityEngine;

namespace Systems.ObjectsPlacingSystem
{
    public class PlacedObjectsFabric : MonoBehaviour
    {
        public static PlacedObjectsFabric Singleton { get; private set; }

        [field:SerializeField] public List<BasePlacingObject> PlacedObjects { get; private set; }
        
        private void Awake()
            => Singleton = this;
        
        public void AddPlacedObject(BasePlacingObject placedObject)
            => PlacedObjects.Add(placedObject);

        public bool TryGetPlacedObject<T>(out T targetObject) where T : BasePlacingObject
        {
            targetObject = default;
            foreach (var placedObject in PlacedObjects)
            {
                if (placedObject is T target)
                {
                    targetObject = target;
                    return true;
                }
            }
            return false;
        }
    }
}