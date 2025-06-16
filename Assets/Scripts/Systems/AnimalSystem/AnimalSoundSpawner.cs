using Sirenix.OdinInspector;
using Systems.SoundSystem;
using UnityEngine;

namespace Systems.AnimalSystem
{
    public class AnimalSoundSpawner : MonoBehaviour
    {
        [Title("Sounds")] [SerializeField] private AudioClip _drinkSound;
        [SerializeField] private AudioClip _eatSound;
        [SerializeField] private AudioClip _barkSound;
        
        public AudioClip DrinkSound => _drinkSound;
        public AudioClip EatSound => _eatSound;
        public AudioClip BarkSound => _barkSound;

        public void PlayDrinkSound()
            => WorldsSoundsSpawner.Singleton.SpawnWorldSound(_drinkSound);
        
        public void PlayEatSound()
            => WorldsSoundsSpawner.Singleton.SpawnWorldSound(_eatSound);
        
        public void PlayBarkSound()
            => WorldsSoundsSpawner.Singleton.SpawnWorldSound(_barkSound);
    }
}