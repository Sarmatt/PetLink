using Meta.WitAi;
using Meta.WitAi.Configuration;
using Meta.WitAi.Requests;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Systems.VoiceRecognitionSystem
{
    public class VoiceRecordingActivator : MonoBehaviour
    {
        [SerializeField] private VoiceService _voiceService;
        
        [Button]
        private void Activate()
            => _voiceService.ActivateImmediately(new WitRequestOptions(), new VoiceServiceRequestEvents());
    }
}