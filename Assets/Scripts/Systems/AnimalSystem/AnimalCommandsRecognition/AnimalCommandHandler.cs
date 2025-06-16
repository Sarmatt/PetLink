using System.Collections.Generic;
using Core;
using Sirenix.OdinInspector;
using Systems.AnimalSystem.StateMachineSystem;
using UnityEngine;

namespace Systems.AnimalSystem.AnimalCommandsRecognition
{
    public class AnimalCommandHandler : MonoBehaviour
    {
        [Title("Attached Components")] [SerializeField]
        private AnimalStateMachine _animalStateMachine;

        private void OnEnable()
            => GlobalEventsContainer.OnCommandRecognized += HandleCommandRecognized;

        private void OnDisable()
            => GlobalEventsContainer.OnCommandRecognized -= HandleCommandRecognized;

        [TextArea] [SerializeField] private List<string> _sitKeys = new List<string>()
        {
            "sit", "seat", "set", "sid", "sith", "shit", "cit", "zit", "sheet",
            "sick", "city", "see it", "seed", "hit", "skip", "ship", "sift", "fit",
            "shut", "stiff", "sin"
        };

        [TextArea] [SerializeField] private List<string> _standUpKeys = new List<string>()
        {
            "stand", "stend", "send", "stat", "stun", "stone", "sand", "stan",
            "stamp", "stank", "stend up", "standup", "startup", "standard", "stack",
            "stay", "step", "start", "hand", "scan"
        };

        private void HandleCommandRecognized(string commandKey)
        {
            var commandKeyLower = commandKey.ToLower();
            if (_sitKeys.Contains(commandKeyLower))
                _animalStateMachine.HandleSitCommand();
            else if (_standUpKeys.Contains(commandKeyLower))
                _animalStateMachine.HandleStandUpCommand();
        }
    }
}