using Firebase;
using UnityEngine;

namespace Systems.FirebaseSystem
{
    public class FirebaseInititalizer : MonoBehaviour
    {
        private void Awake()
            => FirebaseApp.CheckAndFixDependenciesAsync();
    }
}