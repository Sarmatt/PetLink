using Sirenix.OdinInspector;
using Systems.AnimalSystem.StateMachineSystem;
using UnityEngine;

namespace Systems.AnimalSystem
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public class AnimalPettingHandler : MonoBehaviour
    {
        [Title("Attached Components")] 
        [SerializeField] private AnimalStateMachine _animalStateMachine;
        
        private static string _handTag = "Hand";

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(_handTag)) return;
            _animalStateMachine.HandleAnimalPet();
        }
    }
}