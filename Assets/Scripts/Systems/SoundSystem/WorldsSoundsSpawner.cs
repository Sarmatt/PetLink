using UnityEngine;

namespace Systems.SoundSystem
{
    public class WorldsSoundsSpawner : MonoBehaviour
    {
        public static WorldsSoundsSpawner Singleton { get; private set; }

        public void Awake()
            => Singleton = this;

        public void SpawnWorldSound(AudioClip clip)
        {
            var soundObj = new GameObject($"{clip.name} World Sound");
            soundObj.transform.position = transform.position;
            soundObj.AddComponent<WorldSoundsPlayer>().Init(clip);
        }
    }
}