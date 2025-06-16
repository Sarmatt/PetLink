using UnityEngine;

namespace Systems.SoundSystem
{
    public class WorldSoundsPlayer : MonoBehaviour
    {
        public void Init(AudioClip clip)
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.PlayOneShot(clip);
            Destroy(source, clip.length);
        }
    }
}