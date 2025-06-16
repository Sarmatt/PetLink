using Core;
using Meta.WitAi;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Systems.VoiceRecognitionSystem
{
    public class VoiceRecognitionHandler : MonoBehaviour
    {
        [Title("Main Values")]
        [SerializeField] private VoiceService _voiceService;

        private void OnEnable()
        {
            _voiceService.VoiceEvents.OnFullTranscription.AddListener(OnTranscriptionChange);
        }

        private void OnDisable()
        {
            _voiceService.VoiceEvents.OnFullTranscription.RemoveListener(OnTranscriptionChange);
        }

        private void OnTranscriptionChange(string recognizedText)
        {
            Debug.Log(recognizedText);
            GlobalEventsContainer.OnCommandRecognized?.Invoke(recognizedText);
        }
    }
}