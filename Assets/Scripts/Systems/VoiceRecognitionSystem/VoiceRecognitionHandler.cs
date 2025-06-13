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
        
        [Title("Main UI")]
        [SerializeField] private TMP_Text _transcriptionText;

        private void OnEnable()
        {
            _voiceService.VoiceEvents.OnPartialTranscription.AddListener(OnTranscriptionChange);
            _voiceService.VoiceEvents.OnFullTranscription.AddListener(OnTranscriptionChange);
        }

        private void OnDisable()
        {
            _voiceService.VoiceEvents.OnPartialTranscription.RemoveListener(OnTranscriptionChange);
            _voiceService.VoiceEvents.OnFullTranscription.RemoveListener(OnTranscriptionChange);
        }

        private void OnTranscriptionChange(string recognizedText)
        {
            _transcriptionText.text = recognizedText;
        }
    }
}